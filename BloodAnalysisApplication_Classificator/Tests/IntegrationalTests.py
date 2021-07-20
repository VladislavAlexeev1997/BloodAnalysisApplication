import unittest
from unittest.mock import patch, Mock
from NeuralNetworkModule import BloodCellsFuzzyNeuralNetwork
from ImageStructModule import SourceImage

# Класс для интеграционного тестирования нечеткой нейронной сети, 
# классифицирующей объект изображения мазка по типу клеток крови
class BloodCellFuzzyNeuralNetworkIntegrationalTests(unittest.TestCase):
    
    # Инициализация объектов для тестирования
    def setUp(self):
        # Инициализация исследуемого изображения
        self.input_image = SourceImage()
        self.cell_index = 0
        self.image_class = 0
        # Инициализация и обучение нечеткой нейронной сети
        self.bloodCellFuzzyNeurNet = BloodCellsFuzzyNeuralNetwork(self.image_class)
        self.bloodCellFuzzyNeurNet.Fit_Network()
    
    # ИТК-1: на объекте изображения мазка крови 
    #        преобладают пиксели черного цвета
    @patch('ImageStructModule.ImageObject')
    def test_ClassifiedBlackCellObject(self, ImageObjectMock):
        self.Run_Test(ImageObjectMock(), (0, 0, 0), [0, 0])
    
    # ИТК-2: на объекте изображения мазка крови 
    #        преобладают пиксели белого цвета
    @patch('ImageStructModule.ImageObject')
    def test_ClassifiedWhiteCellObject(self, ImageObjectMock):
        self.Run_Test(ImageObjectMock(), (255, 255, 255), [0, 0])
    
    # ИТК-3: объект принадлежит полутоновому изображению
    @patch('ImageStructModule.ImageObject')
    def test_ClassifiedGrayCellObject(self, ImageObjectMock):
        self.Run_Test(ImageObjectMock(), (50, 50, 50), [0, 0])

    # ИТК-4: объект принадлежит полноцветному изображению мазка крови, 
    #        однако он не является ни эритроцитом, ни лейкоцитом
    @patch('ImageStructModule.ImageObject')
    def test_UndefinedClassFullColorCellObject(self, ImageObjectMock):
        self.Run_Test(ImageObjectMock(), (107, 49, 225), [0, 0])
  
    # ИТК-5: объект изображения мазка крови является эритроцитом
    @patch('ImageStructModule.ImageObject')
    def test_ErythrocyteFullColorCellObject(self, ImageObjectMock):
        self.Run_Test(ImageObjectMock(), (220, 199, 167), [1, 0])

    # ИТК-6: объект изображения мазка крови является лейкоцитом
    @patch('ImageStructModule.ImageObject')
    def test_LeukocyteFullColorCellObject(self, ImageObjectMock):
        self.Run_Test(ImageObjectMock(), (133, 135, 150), [0, 1])

    # ИТК-7: объект изображения мазка крови является эритроцитом 
    #        из библиотеки стандартных окрасов клеток крови
    @patch('ImageStructModule.ImageObject')
    def test_BaseErythrocyteColorCellObject(self, ImageObjectMock):
        self.Run_Test(ImageObjectMock(), (212, 191, 156), [1, 0])
   
    # ИТК-8: объект изображения мазка крови является лейкоцитом 
    #        из библиотеки стандартных окрасов клеток крови
    @patch('ImageStructModule.ImageObject')
    def test_BaseLeukocyteCellObject(self, ImageObjectMock):
        self.Run_Test(ImageObjectMock(), (172, 115, 146), [0, 1])

    # Функция запуска тестового случая
    def Run_Test(self, MockObject, RGB_Parameters, Predict_Parameters):
        MockObject.Cell_Object_Max_RGB_Parameters.return_value = RGB_Parameters
        red, green, blue = MockObject.Cell_Object_Max_RGB_Parameters(self.input_image, self.cell_index)
        input_data = [red, green, blue]
        predict_network = self.bloodCellFuzzyNeurNet.Predict_Network(input_data)
        self.assertListEqual(predict_network, Predict_Parameters)

if __name__ == '__main__':
    unittest.main()