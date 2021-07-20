import os
import xml.etree.cElementTree as ET
import NeuralNetworkModule
from ImageStructModule import BloodCell

# Класс для работы с файлами программы
class FileWork:

    _path_name = os.path.dirname(__file__)

    @staticmethod
    def Color_Base_Image_Names():
        color_base_image_names = []
        color_base_image_names.append(FileWork._path_name + '\\Ресурсы\\Типы окраса мазка\\1.png')
        color_base_image_names.append(FileWork._path_name + '\\Ресурсы\\Типы окраса мазка\\2.png')
        color_base_image_names.append(FileWork._path_name + '\\Ресурсы\\Типы окраса мазка\\3.png')
        color_base_image_names.append(FileWork._path_name + '\\Ресурсы\\Типы окраса мазка\\4.png')
        color_base_image_names.append(FileWork._path_name + '\\Ресурсы\\Типы окраса мазка\\5.png')
        color_base_image_names.append(FileWork._path_name + '\\Ресурсы\\Типы окраса мазка\\6.png')
        return color_base_image_names

    @staticmethod
    def Color_Fuzzy_Parameter_File_Name():
        return FileWork._path_name + '\\Ресурсы\\Типы окраса мазка\\Color_Fuzzy_Parameters.xml'

    @staticmethod
    def Color_Fuzzy_Network_File_Name():
        return FileWork._path_name + '\\Ресурсы\\Типы окраса мазка\\Color_Fuzzy_Neural_Network.pkl'

    @staticmethod
    def Blood_Cell_Image_Names():
        blood_cell_base_image_names = [
            [FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\1\\Эритроцит.png', 
             FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\1\\Лейкоцит.png'],
            [FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\2\\Эритроцит.png', 
             FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\2\\Лейкоцит.png'],
            [FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\3\\Эритроцит.png', 
             FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\3\\Лейкоцит.png'],
            [FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\4\\Эритроцит.png', 
             FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\4\\Лейкоцит.png'],
            [FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\5\\Эритроцит.png', 
             FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\5\\Лейкоцит.png'],
            [FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\6\\Эритроцит.png', 
             FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\6\\Лейкоцит.png']]
        return blood_cell_base_image_names

    @staticmethod
    def Blood_Cell_Fuzzy_Parameter_File_Name(class_index):
        if class_index == 0:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\1\\Blood_Cell_Fuzzy_Parameters.xml'
        elif class_index == 1:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\2\\Blood_Cell_Fuzzy_Parameters.xml'
        elif class_index == 2:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\3\\Blood_Cell_Fuzzy_Parameters.xml'
        elif class_index == 3:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\4\\Blood_Cell_Fuzzy_Parameters.xml'
        elif class_index == 4:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\5\\Blood_Cell_Fuzzy_Parameters.xml'
        else:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\6\\Blood_Cell_Fuzzy_Parameters.xml'

    @staticmethod
    def Blood_Cells_Fuzzy_Network_File_Name(class_index):
        if class_index == 0:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\1\\Blood_Cells_Fuzzy_Neural_Network.pkl'
        elif class_index == 1:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\2\\Blood_Cells_Fuzzy_Neural_Network.pkl'
        elif class_index == 2:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\3\\Blood_Cells_Fuzzy_Neural_Network.pkl'
        elif class_index == 3:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\4\\Blood_Cells_Fuzzy_Neural_Network.pkl'
        elif class_index == 4:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\5\\Blood_Cells_Fuzzy_Neural_Network.pkl'
        else:
            return FileWork._path_name + '\\Ресурсы\\Типы клеток мазка\\6\\Blood_Cells_Fuzzy_Neural_Network.pkl'

    @staticmethod
    def Read_Color_Fuzzy_Parameter_File():
        return FileWork._Read_Fuzzy_Parameter_File(
            FileWork.Color_Fuzzy_Parameter_File_Name())

    @staticmethod
    def Read_Blood_Cell_Fuzzy_Parameter_File(class_index):
        return FileWork._Read_Fuzzy_Parameter_File(
            FileWork.Blood_Cell_Fuzzy_Parameter_File_Name(class_index))
        
    @staticmethod
    def _Read_Fuzzy_Parameter_File(load_file_name):
        triangle_functions = []
        XML_tree = ET.parse(load_file_name)
        XML_parameters = XML_tree.getroot()
        for XML_class_parameters in XML_parameters:
            class_triangle_functions = []
            for XML_color_parameters in XML_class_parameters:
                start = int(XML_color_parameters.find("start").text)
                middle = int(XML_color_parameters.find("middle").text)
                end = int(XML_color_parameters.find("end").text)
                class_triangle_functions.append(NeuralNetworkModule.TriangleFunction(start, middle, end))
            triangle_functions.append(class_triangle_functions)
        return triangle_functions
    
    @staticmethod
    def Write_Color_Fuzzy_Parameter_File(color_triangle_functions):
        FileWork._Write_Fuzzy_Parameter_File(color_triangle_functions, 'image',
            FileWork.Color_Fuzzy_Parameter_File_Name())

    @staticmethod
    def Write_Blood_Cell_Fuzzy_Parameter_File(blood_cell_triangle_functions, class_index):
        FileWork._Write_Fuzzy_Parameter_File(blood_cell_triangle_functions, 'blood_cell',
            FileWork.Blood_Cell_Fuzzy_Parameter_File_Name(class_index))

    @staticmethod
    def _Write_Fuzzy_Parameter_File(triangle_functions, object_name, save_file_name):
        XML_parameters = ET.Element('parameters')
        for class_functions in triangle_functions:
            XML_class_parameters = ET.SubElement(XML_parameters, object_name)
            XML_color_parameters = [ET.SubElement(XML_class_parameters, 'red'),
                ET.SubElement(XML_class_parameters, 'green'),
                ET.SubElement(XML_class_parameters, 'blue')]
            for function_index in range(len(class_functions)):
                ET.SubElement(XML_color_parameters[function_index], 
                    'start').text = str(class_functions[function_index].start)
                ET.SubElement(XML_color_parameters[function_index], 
                    'middle').text = str(class_functions[function_index].middle)
                ET.SubElement(XML_color_parameters[function_index], 
                    'end').text = str(class_functions[function_index].end)
        XML_tree = ET.ElementTree(XML_parameters)
        XML_tree.write(save_file_name)
        
    @staticmethod
    def Write_Analysis_Result_File(result_analysis_image):
        XML_image = ET.Element('image')
        XML_size = ET.SubElement(XML_image, 'size')
        ET.SubElement(XML_size, 'width').text = str(result_analysis_image.Width())
        ET.SubElement(XML_size, 'height').text = str(result_analysis_image.Height())
        ET.SubElement(XML_image, 'mean_radius').text = str(result_analysis_image.mean_object_radius)
        ET.SubElement(XML_image, 'image_class').text = str(result_analysis_image.color_class)
        XML_count = ET.SubElement(XML_image, 'count')
        ET.SubElement(XML_count, 'all').text = str(result_analysis_image.Count_All_Cells())
        ET.SubElement(XML_count, 'erithrocytes').text = str(
            result_analysis_image.Count_Cells_By_Type(BloodCell.ERYTHROCYTE))
        ET.SubElement(XML_count, 'leukocytes').text = str(
            result_analysis_image.Count_Cells_By_Type(BloodCell.LEUKOCYTE))
        ET.SubElement(XML_count, 'non').text = str(
            result_analysis_image.Count_Cells_By_Type(BloodCell.NON_IDENTIFY))
        XML_objects = ET.SubElement(XML_image, 'objects')
        for image_object in result_analysis_image.Get_Image_Objects():
            XML_object = ET.SubElement(XML_objects, 'object')
            XML_contour = ET.SubElement(XML_object, 'contour')
            for contour_point in image_object.Get_Contour():
                XML_point = ET.SubElement(XML_contour, 'point')
                ET.SubElement(XML_point, 'x').text = str(contour_point[1])
                ET.SubElement(XML_point, 'y').text = str(contour_point[0])
            XML_cells = ET.SubElement(XML_object, 'cells')
            for cell_object in image_object.Get_Cell_Objects():
                XML_cell = ET.SubElement(XML_cells, 'cell')
                XML_cell_center = ET.SubElement(XML_cell, 'center')
                ET.SubElement(XML_cell_center, 'x').text = str(cell_object.center[1])
                ET.SubElement(XML_cell_center, 'y').text = str(cell_object.center[0])
                ET.SubElement(XML_cell, 'type').text = cell_object.Blood_Cell_Name()
        XML_tree = ET.ElementTree(XML_image)
        path_name = os.path.dirname(result_analysis_image.image_name)
        XML_tree.write(path_name + '\\Результат.xml', encoding='utf-8')