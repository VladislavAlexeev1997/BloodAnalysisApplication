from ImageStructModule import SourceImage
from NeuralNetworkModule import BloodImageAnalysisModel
import sys
import os

if __name__ == '__main__':
    try:
        image_file_name = sys.argv[1]
        source_image = SourceImage(image_name = image_file_name)
        blood_analysis_module = BloodImageAnalysisModel(source_image)
        blood_analysis_module.Complete_Blood_Image_Analysis()
        if (blood_analysis_module.Save_Analysis_Results()):
            print('succsess')
        else:
            print('error')
    except:
        print('error')