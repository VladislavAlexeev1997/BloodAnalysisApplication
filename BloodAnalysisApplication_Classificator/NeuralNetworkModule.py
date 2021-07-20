from abc import ABCMeta, abstractmethod
from ImageStructModule import BloodCellObject, ImageObject, AnalysisImage, BaseImages, ColorBaseImages, BloodCellBaseImages
from ImageProcessingModule import ContourImageProcessing
import FileWorkModule
from sklearn.neural_network import MLPClassifier
from sklearn.externals import joblib
import numpy
import copy
import os

# Класс треугольной функции принадлежности
class TriangleFunction:

    def __init__(self, start, middle, end):
        self.start = start
        self.middle = middle
        self.end = end

    def Membership_Function(self, maxColor):
        if (isinstance(maxColor, int)):
            if (maxColor >= self.start):
                if (maxColor <= self.end):
                    if (maxColor >= self.middle):
                        member = (self.end - maxColor) / (self.end - self.middle)
                    else:
                        member = (maxColor - self.start) / (self.middle - self.start)
                else:
                    member = 0.0
            else:
                member = 0.0
        else:
            member = 0.0
        return member

# Класс-фабрика для формирования нечетко-нейросетевого классификатора
class FuzzyNeuralNetwork(metaclass=ABCMeta):

    def _Load_Base_Images(self):
        return BaseImages([])

    @abstractmethod
    def _Create_Fuzzy_Analyse_Part(self):
        pass

    @abstractmethod
    def _Create_Neural_Network_Part(self):
        pass
    
    @abstractmethod
    def _Fit_Fuzzy_Analyse_Part(self):
        pass

    @abstractmethod
    def _Fit_Neural_Network_Part(self):
        pass
    
    @abstractmethod
    def _Predict_Fuzzy_Analyse_Part(self):
        pass

    @abstractmethod
    def _Predict_Neural_Network_Part(self):
        pass

    @abstractmethod
    def Fit_Network(self):
        pass

    @abstractmethod
    def Predict_Network(self):
        pass

# Класс для формирования нечеткой нейронной сети для определения типа мазка крови
class ColorFuzzyNeuralNetwork(FuzzyNeuralNetwork):

    def __init__(self):
        self._base_images = self._Load_Base_Images()
        self._triangle_functions = self._Create_Fuzzy_Analyse_Part()
        self._neural_network = self._Create_Neural_Network_Part()

    def _Load_Base_Images(self):
        return ColorBaseImages(FileWorkModule.FileWork.Color_Base_Image_Names())

    def _Create_Fuzzy_Analyse_Part(self):
        if self._Is_Fit_Fuzzy_Analyse_Function():
            return FileWorkModule.FileWork.Read_Color_Fuzzy_Parameter_File()
        else:
            return []

    def _Create_Neural_Network_Part(self):
        if self._Is_Fit_Neural_Network():
            return joblib.load(FileWorkModule.FileWork.Color_Fuzzy_Network_File_Name())
        else:
            return MLPClassifier(activation = 'logistic',
                hidden_layer_sizes = (self._base_images.Count_Collection() + 15,), 
                alpha = 1e-5, learning_rate_init = 0.2, max_iter = 10000, random_state = 1)

    def _Is_Fit_Fuzzy_Analyse_Function(self):
        return os.path.isfile(FileWorkModule.FileWork.Color_Fuzzy_Parameter_File_Name())
    
    def _Is_Fit_Neural_Network(self):
        return os.path.isfile(FileWorkModule.FileWork.Color_Fuzzy_Network_File_Name())

    def _Fit_Fuzzy_Analyse_Part(self):
        min_color_parameters, max_color_parameters = ([], [])
        max_RGB_coeffs = [[], [], []]
        while self._base_images.Has_Next_Element():
            colors = self._base_images.Next_Element().Max_RGB_Parameters()
            for color_index in range(len(max_RGB_coeffs)):
                max_RGB_coeffs[color_index].append(colors[color_index])
        sort_max_RGB_coeffs = copy.deepcopy(max_RGB_coeffs)
        for sort_max_color_coeffs in sort_max_RGB_coeffs:
            sort_max_color_coeffs.sort()
        difference = [sort_max_RGB_coeffs[0][1] - sort_max_RGB_coeffs[0][0],
                      sort_max_RGB_coeffs[1][1] - sort_max_RGB_coeffs[1][0],
                      sort_max_RGB_coeffs[2][1] - sort_max_RGB_coeffs[2][0]]
        for index in range(self._base_images.Count_Collection()):
            if (index != 0):
                local_difference = [sort_max_RGB_coeffs[0][index] - sort_max_RGB_coeffs[0][index-1],
                                    sort_max_RGB_coeffs[1][index] - sort_max_RGB_coeffs[1][index-1],
                                    sort_max_RGB_coeffs[2][index] - sort_max_RGB_coeffs[2][index-1]]
                for index_color in range(len(local_difference)):
                    if (local_difference[index_color] > difference[index_color]):
                        difference[index_color] = local_difference[index_color]
        for class_index in range(self._base_images.Count_Collection()):
            class_function_list = []
            for index in range(len(max_RGB_coeffs)):
                triangle_function = TriangleFunction(max_RGB_coeffs[index][class_index] - difference[index], 
                                                     max_RGB_coeffs[index][class_index], 
                                                     max_RGB_coeffs[index][class_index] + difference[index])
                class_function_list.append(triangle_function)
            self._triangle_functions.append(class_function_list)
        for color_index in range(len(difference)):
            min_color_parameters.append(min(sort_max_RGB_coeffs[color_index]) - difference[color_index])
            max_color_parameters.append(max(sort_max_RGB_coeffs[color_index]) + difference[color_index])
        FileWorkModule.FileWork.Write_Color_Fuzzy_Parameter_File(self._triangle_functions)
        return min_color_parameters, max_color_parameters

    def _Fit_Neural_Network_Part(self, min_color_parameters, max_color_parameters):
        input_data, output_data = self._Generate_Fit_Data(min_color_parameters, max_color_parameters)
        self._neural_network.fit(input_data, output_data)
        joblib.dump(self._neural_network, FileWorkModule.FileWork.Color_Fuzzy_Network_File_Name())
    
    def _Generate_Fit_Data(self, min_color_parameters, max_color_parameters):
        input_data, output_data = ([], [])
        for red_input_data in range(min_color_parameters[0], max_color_parameters[0] + 1):
            for green_input_data in range(min_color_parameters[1], max_color_parameters[1] + 1):
                for blue_input_data in range(min_color_parameters[2], max_color_parameters[2] + 1):
                    local_input_data = self._Predict_Fuzzy_Analyse_Part([red_input_data, green_input_data, blue_input_data])
                    local_output_data = numpy.zeros(len(local_input_data))
                    if not(max(local_input_data) == 0.0):
                        local_output_data[local_input_data.index(max(local_input_data))] = 1
                    input_data.append(local_input_data)
                    output_data.append(local_output_data)
        return input_data, output_data

    def _Predict_Fuzzy_Analyse_Part(self, input_data):
        predict_data = []
        for class_function_list in self._triangle_functions:
            result_function = []
            for index_function in range(len(class_function_list)):
                result_function.append(class_function_list[index_function].Membership_Function(input_data[index_function]))
            predict_data.append(min(result_function))
        return predict_data

    def _Predict_Neural_Network_Part(self, input_data):
        return self._neural_network.predict(input_data)

    def Fit_Network(self):
        if not(self._Is_Fit_Fuzzy_Analyse_Function()) or not(self._Is_Fit_Neural_Network()):
            min_color_parameters, max_color_parameters = self._Fit_Fuzzy_Analyse_Part()
            self._Fit_Neural_Network_Part(min_color_parameters, max_color_parameters)

    def Predict_Network(self, input_data):
        return self._Predict_Neural_Network_Part([self._Predict_Fuzzy_Analyse_Part(input_data)])[0].tolist()

# Класс для формирования нечеткой нейронной сети для определения типа клетки крови
class BloodCellsFuzzyNeuralNetwork(FuzzyNeuralNetwork):

    def __init__(self, class_index = 0):
        self._class_network_index = class_index
        self._base_images = self._Load_Base_Images()
        self._triangle_functions = self._Create_Fuzzy_Analyse_Part()
        self._neural_network = self._Create_Neural_Network_Part()

    def _Load_Base_Images(self):
        return BloodCellBaseImages(FileWorkModule.FileWork.Blood_Cell_Image_Names())

    def _Create_Fuzzy_Analyse_Part(self):
        if self._Is_Fit_Fuzzy_Analyse_Function():
            return FileWorkModule.FileWork.Read_Blood_Cell_Fuzzy_Parameter_File(self._class_network_index)
        else:
            return []

    def _Create_Neural_Network_Part(self):
        if self._Is_Fit_Neural_Network():
            return joblib.load(FileWorkModule.FileWork.Blood_Cells_Fuzzy_Network_File_Name(self._class_network_index))
        else:
            return MLPClassifier(activation = 'logistic',
                hidden_layer_sizes =(17,), alpha = 1e-5, 
                learning_rate_init = 0.2, max_iter = 10000, random_state = 1)

    def _Is_Fit_Fuzzy_Analyse_Function(self):
        return os.path.isfile(FileWorkModule.FileWork.Blood_Cell_Fuzzy_Parameter_File_Name(self._class_network_index))

    def _Is_Fit_Neural_Network(self):
        return os.path.isfile(FileWorkModule.FileWork.Blood_Cells_Fuzzy_Network_File_Name(self._class_network_index))

    def _Fit_Fuzzy_Analyse_Part(self):
        min_color_parameters, max_color_parameters = ([], [])
        max_RGB_coeffs = [[], [], []]
        for class_image in self._base_images.Element_For_Index(self._class_network_index):
            colors = class_image.Max_RGB_Parameters()
            for color_index in range(len(max_RGB_coeffs)):
                max_RGB_coeffs[color_index].append(colors[color_index])
        sort_max_RGB_coeffs = copy.deepcopy(max_RGB_coeffs)
        for sort_max_color_coeffs in sort_max_RGB_coeffs:
            sort_max_color_coeffs.sort()
        difference = 32
        for class_index in range(len(self._base_images.Element_For_Index(self._class_network_index))):
            class_function_list = []
            for index in range(len(max_RGB_coeffs)):
                triangle_function = TriangleFunction(max_RGB_coeffs[index][class_index] - difference, 
                                                     max_RGB_coeffs[index][class_index], 
                                                     max_RGB_coeffs[index][class_index] + difference)
                class_function_list.append(triangle_function)
            self._triangle_functions.append(class_function_list)
        for color_index in range(len(sort_max_RGB_coeffs)):
            min_color = min(sort_max_RGB_coeffs[color_index]) - difference
            if (min_color < 0):
                min_color = 0
            min_color_parameters.append(min_color)
            max_color = max(sort_max_RGB_coeffs[color_index]) + difference
            if (max_color > 255):
                max_color = 255
            max_color_parameters.append(max_color)
        FileWorkModule.FileWork.Write_Blood_Cell_Fuzzy_Parameter_File(self._triangle_functions, self._class_network_index)
        return min_color_parameters, max_color_parameters

    def _Fit_Neural_Network_Part(self, min_color_parameters, max_color_parameters):
        input_data, output_data = self._Generate_Fit_Data(min_color_parameters, max_color_parameters)
        self._neural_network.fit(input_data, output_data)
        joblib.dump(self._neural_network, FileWorkModule.FileWork.Blood_Cells_Fuzzy_Network_File_Name(self._class_network_index))    
    
    def _Generate_Fit_Data(self, min_color_parameters, max_color_parameters):
        input_data, output_data = ([], [])
        for red_input_data in range(min_color_parameters[0], max_color_parameters[0] + 1):
            for green_input_data in range(min_color_parameters[1], max_color_parameters[1] + 1):
                for blue_input_data in range(min_color_parameters[2], max_color_parameters[2] + 1):
                    local_input_data = self._Predict_Fuzzy_Analyse_Part([red_input_data, green_input_data, blue_input_data])
                    local_output_data = numpy.zeros(len(local_input_data))
                    if not(max(local_input_data) == 0.0):
                        local_output_data[local_input_data.index(max(local_input_data))] = 1
                    input_data.append(local_input_data)
                    output_data.append(local_output_data)
        return input_data, output_data

    def _Predict_Fuzzy_Analyse_Part(self, input_data):
        predict_data = []
        for class_function_list in self._triangle_functions:
            result_function = []
            for index_function in range(len(class_function_list)):
                result_function.append(class_function_list[index_function].Membership_Function(input_data[index_function]))
            predict_data.append(min(result_function))
        return predict_data

    def _Predict_Neural_Network_Part(self, input_data):
        return self._neural_network.predict(input_data)

    def Fit_Network(self):
        if not(self._Is_Fit_Fuzzy_Analyse_Function()) or not(self._Is_Fit_Neural_Network()):
            min_color_parameters, max_color_parameters = self._Fit_Fuzzy_Analyse_Part()
            self._Fit_Neural_Network_Part(min_color_parameters, max_color_parameters)

    def Predict_Network(self, input_data):
        return self._Predict_Neural_Network_Part([self._Predict_Fuzzy_Analyse_Part(input_data)])[0].tolist()

# Класс проведения полного интелектуального анализа изображения мазка крови
class BloodImageAnalysisModel:

    def __init__(self, source_image):
        self._input_source_image = source_image

    def Complete_Blood_Image_Analysis(self):
        color_class_index = self._Complete_Class_Color_Image_Analysis()
        find_image_objects, mean_radius = self._Complete_Find_Image_Objects()
        self._Complete_Class_Image_Objects_Analysis(find_image_objects, color_class_index)
        self._result_image = AnalysisImage(self._input_source_image.image_name, self._input_source_image.image, 
            color_class_index + 1, find_image_objects, mean_radius)

    def Save_Analysis_Results(self):
        if not(self._result_image == None):
            FileWorkModule.FileWork.Write_Analysis_Result_File(self._result_image)
            return True
        else:
            return False

    def _Complete_Class_Color_Image_Analysis(self):
        max_red, max_green, max_blue = self._input_source_image.Max_RGB_Parameters()
        color_fuzzy_neural_network = ColorFuzzyNeuralNetwork()
        color_fuzzy_neural_network.Fit_Network()
        predict_result = color_fuzzy_neural_network.Predict_Network([max_red, max_green, max_blue])
        if not(max(predict_result) == 0):
            color_class_index = predict_result.index(max(predict_result))
        else:
            color_class_index = -1
        return color_class_index

    def _Complete_Find_Image_Objects(self):
        contours, centers, mean_radius = ContourImageProcessing.Find_contours(self._input_source_image)
        image_objects = []
        for contour_index in range(len(contours)):
            find_cell_objects = []
            for contour_center in centers[contour_index]:
                cell_object = BloodCellObject(center = contour_center)
                find_cell_objects.append(cell_object)
            image_object = ImageObject(contour = contours[contour_index], cell_objects = find_cell_objects)
            image_objects.append(image_object)
        return image_objects, mean_radius

    def _Complete_Class_Image_Objects_Analysis(self, image_objects, class_index):
        cells_fuzzy_neural_network = BloodCellsFuzzyNeuralNetwork(class_index)
        cells_fuzzy_neural_network.Fit_Network()
        for object_index in range(len(image_objects)):
            for cell_index in range(image_objects[object_index].Count_Cell_Objects()):
                max_red, max_green, max_blue = image_objects[object_index].Cell_Object_Max_RGB_Parameters(
                    self._input_source_image, cell_index)
                predict_result = cells_fuzzy_neural_network.Predict_Network([max_red, max_green, max_blue])
                if not(max(predict_result) == 0):
                    cell_class_index = predict_result.index(max(predict_result)) + 1
                else:
                    cell_class_index = 0
                image_objects[object_index].Get_Cell_Object(cell_index).type_number = cell_class_index