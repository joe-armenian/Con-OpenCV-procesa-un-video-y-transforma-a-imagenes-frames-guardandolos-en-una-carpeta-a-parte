using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ProyectoDAmerdjianJoel
{
     class ConvertirAframes
    {
        static void Main(string[] args)
        {


            
            string videoPath = "./MiVideo/10segundosvideo.mp4"; //<- lo ubique al video en la carpeta donde se encuentra este ejecutable por eso no detallo con C:/...etc.

            
            string outputFolder = "MiVideoenFrames"; //la carpeta donde lo voy a guardar

           
            VideoCapture videoCapture = new VideoCapture(videoPath);

           
            if (!videoCapture.IsOpened)
            {
                Console.WriteLine("Error al abrir el video,verificar!!.");  // si ocurre un problema al ubicar el video, muestre un msj de error y finaliza la ejecución.
                return;
            }


            if (!System.IO.Directory.Exists(outputFolder))
            {                                                       //Algo que se suele utilizar en archivos como cuando usababamos el openOrcreate
                System.IO.Directory.CreateDirectory(outputFolder);  // en caso de no existir la carpeta, crear la carpeta de salida 
            }

            // Procesar cada frame del video
            int frameCount = Convert.ToInt32(videoCapture.Get(CapProp.FrameCount));
            for (int i = 0; i < frameCount; i++)
            {
                // Leer el siguiente frame
                Mat frame = new Mat();
                videoCapture.Read(frame);

                // Guardar el frame como imagen
                string outputPath = System.IO.Path.Combine(outputFolder, $"frame_{i}.png");
                CvInvoke.Imwrite(outputPath, frame);
            }

            Console.WriteLine("Proceso completado. Frames guardados en la carpeta de salida,gracias!!");
            Console.ReadLine();

        }
    }

  

}

