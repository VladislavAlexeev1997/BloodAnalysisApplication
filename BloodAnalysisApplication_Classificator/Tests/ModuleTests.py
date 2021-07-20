import unittest 
from NeuralNetworkModule import TriangleFunction

# Класс для модульного тестирования функции Membership_Function класса TriangleFunction
class TriangleFunctionModuleTests(unittest.TestCase):
    
    # Инициализация объекта треугольной функции принадлежности TriangleFunction
    def setUp(self):
        self.triangleFunc = TriangleFunction(115, 135, 160)

    # МТ-1: функции передан пустой объект
    def test_NoneInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(None), 0.0)

    # МТ-2: функции передана строка
    def test_StringInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function('127'), 0.0)

    # МТ-3: функции передано вещественное число
    def test_FloatInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(119.83), 0.0)

    # МТ-4: функции передано число, меньшее минимального левого значения
    def test_LeftMoreUnownedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(84), 0.0)

    # МТ-5: функции передано число, меньшее минимального левого значения на 1
    def test_LeftUnownedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(114), 0.0)

    # МТ-6: функции передано число, равное минимальному левому значению
    def test_LeftBorderInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(115), 0.0)

    # МТ-7: функции передано число, большее минимального левого значения на 1
    def test_LeftBorderOwnedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(116), 0.05)
    
    # МТ-8: функции передано число, находится в диапазоне от минимального левого значения 
    #       до максимального значения функции принадлежности
    def test_LeftOwnedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(124), 0.45)

    # МТ-9: функции передано число, меньшее максимального значения на 1
    def test_CenterLeftOwnedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(134), 0.95)

    # МТ-10: функции передано число, равное максимальному значению
    def test_CenterInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(135), 1)

    # МТ-11: функции передано число, большее максимального значения на 1
    def test_CenterLRightOwnedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(136), 0.96)

    # МТ-12: функции передано число, находится в диапазоне от максимального значения  
    #        до минимального правого значения функции принадлежности
    def test_RightOwnedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(149), 0.44)

    # МТ-13: функции передано число, меньшее минимального правого значения на 1
    def test_RightBorderOwnedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(159), 0.04)

    # МТ-14: функции передано число, равное минимальному правому значению
    def test_RightBorderInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(160), 0.0)

    # МТ-15: функции передано число, большее минимального правого значения на 1
    def test_RightUnownedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(161), 0.0)

    # МТ-16: функции передано число, большее минимального правого значения
    def test_RightMoreUnownedInputParameter(self):
        self.assertEqual(self.triangleFunc.Membership_Function(210), 0.0)

if __name__ == '__main__':
    unittest.main()
