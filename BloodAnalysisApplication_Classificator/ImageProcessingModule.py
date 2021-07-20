import ImageStructModule
from skimage import measure, img_as_float
from skimage.morphology import disk
from PIL import Image, ImageDraw
from matplotlib import path
import copy
import numpy
import math
import cv2

# Класс, реализующий процесс обработки изображений по цветовым характеристикам
class ColorImageProcessing:

    @staticmethod
    def Max_RGB_Image_Parameters(source_image):
        return ColorImageProcessing._Max_RGB_Parameters(
            ColorImageProcessing._RGB_Image_Histogram(source_image))

    @staticmethod
    def _RGB_Image_Histogram(source_image):
        red_counters, green_counters, blue_counters = numpy.zeros((3, 256))
        for width_pixel in range(source_image.Width()):
            for height_pixel in range(source_image.Height()):
                red, green, blue = source_image.image.getpixel((width_pixel, height_pixel))
                red_counters[red] += 1
                green_counters[green] += 1
                blue_counters[blue] += 1
        return red_counters, green_counters, blue_counters

    @staticmethod
    def Max_RGB_Contour_Parameters(source_image, contour):
        return ColorImageProcessing._Max_RGB_Parameters(
            ColorImageProcessing._RGB_Contour_Histogram(source_image, contour))

    @staticmethod
    def _RGB_Contour_Histogram(source_image, contour):
        x_coords = [point[1] for point in contour]
        y_coords = [point[0] for point in contour]
        x_min, x_max = int(min(x_coords)), int(max(x_coords))
        y_min, y_max = int(min(y_coords)), int(max(y_coords))
        red_counters, green_counters, blue_counters = numpy.zeros((3, 256))
        for x_coef in range(x_max - x_min + 1):
            for y_coef in range(y_max - y_min + 1):
                is_point_in_contour = ContourImageProcessing.Is_Point_In_Contour(contour, x_min + x_coef, y_min + y_coef)
                if(is_point_in_contour):
                    red, green, blue = source_image.image.getpixel((x_min + x_coef, y_min + y_coef))
                    red_counters[red] += 1
                    green_counters[green] += 1
                    blue_counters[blue] += 1
        return red_counters, green_counters, blue_counters

    @staticmethod
    def _Max_RGB_Parameters(color_counters):
        red_counters, green_counters, blue_counters = color_counters
        red_max, green_max, blue_max = 0, 0, 0
        for index in range(256):
            if (red_counters[index] > red_max):
                red_max_index = index
                red_max = red_counters[index]
            if (green_counters[index] > green_max):
                green_max_index = index
                green_max = green_counters[index]
            if (blue_counters[index] > blue_max):
                blue_max_index = index
                blue_max = blue_counters[index]
        return red_max_index, green_max_index, blue_max_index
       
    @staticmethod
    def Image_To_Gray(source_image):
        gray_image = Image.new('L', source_image.image.size)
        for width_pixel in range(source_image.Width()):
            for height_pixel in range(source_image.Height()):
                red, green, blue = source_image.image.getpixel((width_pixel, height_pixel))
                gray = int(0.299 * red + 0.587 * green + 0.114 * blue)
                gray_image.putpixel((width_pixel, height_pixel), gray)
        return ImageStructModule.SourceImage(image = gray_image)

    @staticmethod
    def Image_To_Binary(source_image):
        binary_source_image = ColorImageProcessing.Image_To_Gray(source_image)
        brightness = ColorImageProcessing._Otsu_Binary_Threshold(binary_source_image)
        for width_pixel in range(source_image.Width()):
            for height_pixel in range(source_image.Height()): 
                gray = binary_source_image.image.getpixel((width_pixel, height_pixel))
                if gray > brightness:
                    binary_source_image.image.putpixel((width_pixel, height_pixel), 255)
                else:
                    binary_source_image.image.putpixel((width_pixel, height_pixel), 0)
        return binary_source_image

    @staticmethod
    def _Otsu_Binary_Threshold(gray_source_image):
        histogram, all_intensity_sum = ColorImageProcessing._Gray_Image_Histogram(gray_source_image)
        all_pixel_count = int(gray_source_image.Width() * gray_source_image.Height())
        best_thresh = 0
        best_sigma = 0.0
        first_class_pixel_count = 0
        first_class_intensity_sum = 0
        for thresh in range(256):
            first_class_pixel_count += histogram[thresh]
            first_class_intensity_sum += thresh * histogram[thresh]
            first_class_prob = first_class_pixel_count / all_pixel_count
            second_class_prob = 1.0 - first_class_prob
            if first_class_pixel_count == 0:
                first_class_mean = 0.0
            else:
                first_class_mean = first_class_intensity_sum / first_class_pixel_count
            if all_pixel_count == first_class_pixel_count:
                second_class_mean = 0.0
            else:
                second_class_mean = (all_intensity_sum - first_class_intensity_sum) / (all_pixel_count - first_class_pixel_count)
            mean_delta = first_class_mean - second_class_mean
            sigma = first_class_prob * second_class_prob * mean_delta * mean_delta
            if (sigma > best_sigma):
                best_sigma = sigma
                best_thresh = thresh
        return best_thresh

    @staticmethod
    def _Gray_Image_Histogram(gray_source_image):
        gray_counters = numpy.zeros(256)
        sum_intensive = 0
        for width_pixel in range(gray_source_image.Width()):
            for height_pixel in range(gray_source_image.Height()):
                gray = gray_source_image.image.getpixel((width_pixel, height_pixel))
                gray_counters[gray] += 1
                sum_intensive += gray
        return gray_counters, sum_intensive

    @staticmethod
    def _Edit_For_Size_Image(source_image, step):
        result_image = Image.new(source_image.image.mode, 
            (source_image.Width() + 2 * step, source_image.Height() + 2 * step), 255)
        if (step > 0):
            imput_porog = 0
        else:
            imput_porog = abs(step)
        for x in range(imput_porog, source_image.Width()):
            for y in range(imput_porog, source_image.Height()):
                result_x = x + step
                result_y = y + step
                result_image.putpixel((result_x, result_y), source_image.image.getpixel((x, y)))
        return ImageStructModule.SourceImage(image = result_image)

# Класс, реализующий процесс нахождения и обработки контуров изображений
class ContourImageProcessing:
    
    @staticmethod
    def Is_Point_In_Contour(contour, x_point, y_point):
        path_contour = path.Path(contour)
        is_point_in_contour = path_contour.contains_point([y_point, x_point])
        return is_point_in_contour

    @staticmethod
    def Drawing_All_Contours(source_image, contours, centers):
        result_image = copy.deepcopy(source_image.image)
        object_number = 0
        for contour_idx in range(len(contours)):
            result_sourse_image = ContourImageProcessing.Drawing_Contour(
                ImageStructModule.SourceImage(image = result_image), 
                contours, centers, contour_idx, object_number + 1)
            object_number += len(centers[contour_idx])
            result_image = result_sourse_image.image
        return ImageStructModule.SourceImage(image = result_image)

    @staticmethod
    def Distribution_Contour_Points_For_Centers(contour, centers):
        center_contours = ContourImageProcessing._Generate_List_Of_Components([], len(centers))
        for point in contour:
            min_distance = 1000000
            claster_index = 0
            for center_index in range(len(centers)):
                distance = ContourImageProcessing._Point_Distance(point, centers[center_index])
                if distance < min_distance:
                    min_distance = distance
                    claster_index = center_index
            center_contours[claster_index].append(point)
        return center_contours

    @staticmethod
    def Drawing_Contour(source_image, contours, centers, index, start_number = 1):
        contour = contours[index]
        contour_centers = centers[index]
        result_image = copy.deepcopy(source_image.image)
        for point_contour in contour:
            result_x = int(point_contour[1])
            result_y = int(point_contour[0])
            result_image.putpixel((result_x, result_y), (255, 0, 0))
        center_number = start_number
        for center in contour_centers:
            draw_text = ImageDraw.Draw(result_image)
            draw_text.text((center[1], center[0]), str(center_number), fill=('#1C0606'))
            center_number += 1
        return ImageStructModule.SourceImage(image = result_image)

    @staticmethod
    def Find_contours(source_image):
        all_contours = ContourImageProcessing._Find_All_Contours(source_image)
        correct_contours_by_area = ContourImageProcessing._Select_Contours_By_Area(all_contours)
        contours_without_internal = ContourImageProcessing._Delete_Internal_Contours(correct_contours_by_area)
        contour_centers, mean_radius = ContourImageProcessing._Find_Centers_Of_Contours(source_image, contours_without_internal)
        return contours_without_internal, contour_centers, mean_radius

    @staticmethod
    def _Find_All_Contours(source_image):
        source_binary_image = ColorImageProcessing._Edit_For_Size_Image(
            ColorImageProcessing.Image_To_Binary(source_image), 1)
        float_resource_image = img_as_float(source_binary_image.image)
        binary_image = float_resource_image < 0.5
        find_contours = measure.find_contours(binary_image, 0.)
        correct_find_contours = ContourImageProcessing._Correct_Find_All_Contours(
            source_binary_image, find_contours)
        return correct_find_contours

    @staticmethod
    def _Correct_Find_All_Contours(source_binary_image, contours):
        correct_contours = contours.copy()
        for contour in correct_contours:
            for contour_point in contour:
                x_coord = int(contour_point[1])
                y_coord = int(contour_point[0])
                if x_coord > 0 and x_coord < source_binary_image.Width() - 1:
                    contour_point[1] -= 1.0
                elif x_coord == source_binary_image.Width() - 1:
                    contour_point[1] -= 2.0
                if y_coord > 0 and y_coord < source_binary_image.Height() - 1:
                    contour_point[0] -= 1.0
                elif y_coord == source_binary_image.Height() - 1:
                    contour_point[0] -= 2.0
        return correct_contours

    @staticmethod
    def _Select_Contours_By_Area(contours):
        mean_area, areas = ContourImageProcessing._Calculate_Middle_Contour_Area(contours)
        correct_contours = []
        for contour_index in range(len(contours)):
            if areas[contour_index] >= mean_area:
                correct_contours.append(contours[contour_index])
        return correct_contours

    @staticmethod
    def _Calculate_Middle_Contour_Area(contours):
        mean_area = 0.0
        areas = []
        for contour in contours:
            areas.append(ContourImageProcessing._Calculate_Contour_Area(contour))
        mean_area = sum(areas) / len(areas)
        return mean_area, areas
    
    @staticmethod
    def _Calculate_Contour_Area(contour):
        area = 0.0
        if len(contour) > 2:
            array_contour = numpy.array(contour)
            format_array_contour = numpy.expand_dims(
                array_contour.astype(numpy.float32), 1)
            UMat_array_contour = cv2.UMat(format_array_contour)
            area = cv2.contourArea(UMat_array_contour)
        return area

    @staticmethod
    def _Delete_Internal_Contours(contours):
        correct_contours = []
        for intern_cont_index in range(len(contours)):
            is_contour_in_other = False 
            for contour_index in range(len(contours)):
                if not(contour_index == intern_cont_index):
                    points_in_contour_count = 0
                    for point_contour in contours[intern_cont_index]:
                        is_point_in_contour = ContourImageProcessing.Is_Point_In_Contour(
                            contours[contour_index], int(point_contour[1]), int(point_contour[0]))
                        if is_point_in_contour:
                            points_in_contour_count += 1
                    if points_in_contour_count > len(contours[intern_cont_index]) / 2:
                        is_contour_in_other = True
                if is_contour_in_other:
                    break
            if not(is_contour_in_other):
                correct_contours.append(contours[intern_cont_index])
        return correct_contours

    @staticmethod
    def _Find_Centers_Of_Contours(source_image, contours):
        mean_radius = ContourImageProcessing._Calculate_Mean_Contour_Radius(contours)
        contour_centers = []
        for contour in contours:
            max_contour_radius = ContourImageProcessing._Calculate_Max_Contour_Radius(contour)
            predict_center_count = int(math.ceil(max_contour_radius / mean_radius))
            if predict_center_count > 1:
                steps = int(mean_radius / predict_center_count)
                for step in range(steps):
                    erode_contours = ContourImageProcessing._Find_New_Contours_By_Erode_Morphology(
                        contour, source_image, (step + 1) * predict_center_count)
                    if(len(erode_contours) >= predict_center_count):
                        new_contour_centers = ContourImageProcessing._Calculate_New_Contour_Centers(erode_contours)
                        contour_centers.append(new_contour_centers)
                        break
                    elif step + 1 >= steps:
                        center_x, center_y = ContourImageProcessing._Calculate_Center_Moment_Point(contour)
                        contour_centers.append([numpy.array([center_y, center_x])])
            else:
                center_x, center_y = ContourImageProcessing._Calculate_Center_Moment_Point(contour)
                contour_centers.append([numpy.array([center_y, center_x])])
        return contour_centers, mean_radius

    @staticmethod
    def _Calculate_Mean_Contour_Radius(contours):
        mean_area, _ = ContourImageProcessing._Calculate_Middle_Contour_Area(contours)
        mean_radius = int(numpy.sqrt(mean_area / numpy.pi))
        return mean_radius

    @staticmethod
    def _Calculate_Center_Moment_Point(contour):
        center_x, center_y = (0, 0)
        for point in contour:
            center_x += point[1]
            center_y += point[0]
        center_x, center_y = (int(center_x / len(contour)),
            int(center_y / len(contour)))
        return center_x, center_y

    @staticmethod
    def _Calculate_Max_Contour_Radius(contour):
        center_x, center_y = ContourImageProcessing._Calculate_Center_Moment_Point(contour)
        contour_radiudes = []
        for point in contour:
            distance = ContourImageProcessing._Point_Distance(point, (center_y, center_x))
            contour_radiudes.append(distance)
        max_radius = max(contour_radiudes)
        return max_radius

    @staticmethod
    def _Point_Distance(first_point, second_point):
        distance = numpy.sqrt((first_point[0] - second_point[0]) ** 2 
            + (first_point[1] - second_point[1]) ** 2)
        return distance

    @staticmethod
    def _Find_New_Contours_By_Erode_Morphology(contour, source_image, erode_step):
        mask_image = numpy.full((source_image.Height(), source_image.Width()), 
            0, dtype = numpy.uint8)
        array_contours = ContourImageProcessing._Contours_To_Array([contour])
        cv2.drawContours(mask_image, array_contours, 0, 255)
        cv2.fillPoly(mask_image, pts = [array_contours[0]], color = 255)
        erode_image = cv2.erode(mask_image, disk(erode_step, dtype = numpy.uint8))
        erode_contours, _ = cv2.findContours(numpy.uint8(erode_image.copy()), 
            cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
        return erode_contours

    @staticmethod
    def _Calculate_New_Contour_Centers(erode_contours):
        new_contour_centers = []
        for contour in erode_contours:
            contour_moments = cv2.moments(contour)
            if contour_moments['m00'] == 0.0:
                coord_x, coord_y = (contour[0][0][0], contour[0][0][1])
            else:
                coord_x = int(contour_moments['m10'] / contour_moments['m00'])
                coord_y = int(contour_moments['m01'] / contour_moments['m00'])
            new_contour_centers.append(numpy.array([coord_y, coord_x]))
        return new_contour_centers

    @staticmethod
    def _Contours_To_Array(contours):
        array_contours = []
        for contour in contours:
            array_contour = []
            for point in contour:
                array_point = numpy.array([int(point[1]), int(point[0])])
                array_contour.append(array_point)
            array_contours.append(numpy.array(array_contour))
        return numpy.array(array_contours)

    @staticmethod
    def _Generate_List_Of_Components(component, count):
        new_list = []
        for index in range(count):
            new_list.append(component.copy())
        return new_list