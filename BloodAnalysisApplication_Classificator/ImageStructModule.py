from enum import Enum
from PIL import Image
import ImageProcessingModule
from abc import ABCMeta, abstractmethod
import numpy

# Класс-перечисление типов клеток крови
class BloodCell(Enum):
    
    NON_IDENTIFY = 0
    ERYTHROCYTE = 1
    LEUKOCYTE = 2

# Класс, описывающий объект клетки крови
class BloodCellObject:

    def __init__(self, center = numpy.array([0, 0]), type_number = BloodCell.NON_IDENTIFY):
        self.center = center
        self.type_number = type_number
        
    def Blood_Cell_Name(self):
        CYTE_NAME_DICTIONARY = {
            0 : 'не распознан',
            1 : 'эритроцит',
            2 : 'лейкоцит'}
        return CYTE_NAME_DICTIONARY[self.type_number]

# Класс, описывающий распознанный объект на изображении
class ImageObject:

    def __init__(self, contour = [], cell_objects = []):
        self._contour = contour
        self._cell_objects = cell_objects

    def Add_Contour_Point(self, x_coord, y_coord):
        self._contour.append(numpy.array([y_coord, x_coord]))

    def Add_Cell_Object(self, cell_object):
        self._cell_objects.append(cell_object)

    def Delete_Contour_Point(self, index):
        if index < self.Count_Contour_Points():
            self._contour.pop(index)

    def Delete_Cell_Object(self, index):
        if index < self.Count_Cell_Objects():
            self._cell_objects.pop(index)

    def Get_Contour_Point(self, index):
        if index < self.Count_Contour_Points():
            return (self._contour[index][1], self._contour[index][0])
        else:
            return (0, 0)

    def Get_Cell_Object(self, index):
        if index < self.Count_Cell_Objects():
            return self._cell_objects[index]
        else:
            return BloodCellObject()

    def Get_Contour(self):
        return self._contour

    def Get_Cell_Objects(self):
        return self._cell_objects

    def Cell_Object_Max_RGB_Parameters(self, image, index):
        if len(self._cell_objects) > 1:
            object_centers = [cell_object.center for cell_object in self._cell_objects]
            object_contour = ImageProcessingModule.ContourImageProcessing.Distribution_Contour_Points_For_Centers(
                self._contour, object_centers)[index]
        else:
            object_contour = self._contour
        return ImageProcessingModule.ColorImageProcessing.Max_RGB_Contour_Parameters(image, object_contour)

    def Count_Contour_Points(self):
        return len(self._contour)

    def Count_Cell_Objects(self):
        return len(self._cell_objects)

    def Count_Cells_By_Type(self, blood_cell_type):
        cell_count = 0
        for cell_object in self._cell_objects:
            if cell_object.type_number == blood_cell_type.value:
                cell_count += 1
        return cell_count

# Базовый класс, описывающий изображение как объект
class SourceImage(metaclass=ABCMeta):

    def __init__(self, image_name = 'temp.jpg', image = None):
        self.image_name = image_name
        if self.image_name == 'temp.jpg':
            self.image = image
        else:
            self.image = Image.open(image_name).convert('RGB')
        if self.image == None:
            self.shape = (0, 0)
        else:
            self.shape = (self.image.size[0], self.image.size[1])

    def Width(self):
        return self.shape[0]

    def Height(self):
        return self.shape[1]

    def Max_RGB_Parameters(self):
        return ImageProcessingModule.ColorImageProcessing.Max_RGB_Image_Parameters(self)

# Класс анализируемого изображения мазка крови
class AnalysisImage(SourceImage):

    def __init__(self, image_name = 'temp.jpg', image = None, color_class = 0, image_objects = [], mean_object_radius = 0):
        super().__init__(image_name, image)
        self.color_class = color_class
        self.mean_object_radius = mean_object_radius
        self._image_objects = image_objects

    def Add_Image_Object(self, new_object):
        self._image_objects.append(new_object)

    def Delete_Image_Object(self, index):
        if index < self.Count__Image_Objects():
            self._image_objects.pop(index)

    def Get_Image_Object(self, index):
        if index < self.Count_Image_Objects():
            return self._image_objects[index]
        else:
            return ImageObject()

    def Get_Image_Objects(self):
        return self._image_objects

    def Count_Image_Objects(self):
        return len(self._image_objects)

    def Count_All_Cells(self):
        cell_count = 0
        for image_object in self._image_objects:
            cell_count += image_object.Count_Cell_Objects()
        return cell_count

    def Count_Cells_By_Type(self, blood_cell_type):
        cell_count = 0
        for image_object in self._image_objects:
            cell_count += image_object.Count_Cells_By_Type(blood_cell_type)
        return cell_count

# Основной класс коллекции базовых изображений
class BaseImages(metaclass=ABCMeta):

    def __init__(self, collection = []):
        self._image_collection = collection
        self._now_cursor = -1

    @abstractmethod
    def Now_Element(self):
        pass

    @abstractmethod
    def Next_Element(self):
        pass

    @abstractmethod
    def Has_Next_Element(self):
        pass

    def Element_For_Index(self, index):
        return self._image_collection[index]

    def Count_Collection(self):
        return len(self._image_collection)

# Класс коллекции изображений стандартных окрасов мазков крови
class ColorBaseImages(BaseImages):
    
    def __init__(self, image_names = []):
        super().__init__(self._Load_Images(image_names))

    def _Load_Images(self, image_names):
        collection = []
        for base_image_name in image_names:
            collection.append(SourceImage(image_name = base_image_name))
        return collection

    def Now_Element(self):
        if self._now_cursor < 0:
            return self._image_collection[0]
        else:
            return self._image_collection[self._now_cursor]

    def Next_Element(self):
        if self.Has_Next_Element():
            self._now_cursor += 1
            return self._image_collection[self._now_cursor]
        else:
            return None

    def Has_Next_Element(self):
        return len(self._image_collection) > self._now_cursor + 1

# Класс колекции изображений клеток крови стандартных окрасов мазков
class BloodCellBaseImages(BaseImages):
    
    def __init__(self, image_names = []):
        super().__init__(self._Load_Images(image_names))

    def _Load_Images(self, image_names):
        collection = []
        for blood_cell_images_names in image_names:
            blood_cells = []
            for base_image_name in blood_cell_images_names:
                blood_cells.append(SourceImage(image_name = base_image_name))
            collection.append(blood_cells)
        return collection

    def Now_Element(self):
        if self._now_cursor < 0:
            return self._image_collection[0]
        else:
            return self._image_collection[self._now_cursor]

    def Now_Erythrocyte_Image(self):
        return self.Now_Element()[0]
    
    def Now_Leukocyte_Image(self):
        return self.Now_Element()[1]

    def Next_Element(self):
        if self.Has_Next_Element():
            self._now_cursor += 1
            return self._image_collection[self._now_cursor]
        else:
            return None

    def Has_Next_Element(self):
        return len(self._image_collection) > self._now_cursor + 1

    def Erythrocyte_Image_For_Index(self):
        return self.Element_For_Index()[0]
    
    def Leukocyte_Image_For_Index(self):
        return self.Element_For_Index()[1]