using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2020-2021 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 
**				ÖĞRENCİ ADI............: EMİR ÖNDER DEMİRCAN
**				ÖĞRENCİ NUMARASI.......: b191210450
**              DERSİN ALINDIĞI GRUP...: 1-A
****************************************************************************/

namespace ÖDEV1
{
    class b191210450_Odev_1
    {
        static void Main(string[] args)
        {
            float classAvarage = 0;
            int countAA = 0;    // AA notuna ait initial değer
            int countBA = 0;    // BA notuna ait initial değer
            int countBB = 0;    // BB notuna ait initial değer
            int countCB = 0;    // CB notuna ait initial değer
            int countCC = 0;    // CC notuna ait initial değer
            int countDC = 0;    // DC notuna ait initial değer
            int countDD = 0;    // DD notuna ait initial değer
            int countFD = 0;    // FD notuna ait initial değer
            int countFF = 0;    // FF notuna ait initial değer
            int countEKSIK = 0; // EKSİK notuna ait initial değer
            string fileData = "";
            string fileName = "StudentGradeCalculator.txt";
            string resultFileName = "StudentGradeCalculator_Result.txt";
            string[] students = File.ReadAllLines(fileName, Encoding.UTF8);

            Console.WriteLine("Öğrenci harf notları hesaplanmaya başlıyor...");

            // Dosyadan okunan satırlar tek tek alınır.
            foreach (string student in students)
            {

                // , ile öğrenci bilgileri parçalara ayrılır ve ilgili değişkenlere atanır.
                string[] studentInfo = student.Split(',');
                string name = studentInfo[0];
                string studentNumber = studentInfo[1];
                int homeworkGrade = int.Parse(studentInfo[2]);
                int projectGrade = int.Parse(studentInfo[3]);
                int midtermGrade = int.Parse(studentInfo[4]); 
                int finalGrade = int.Parse(studentInfo[5]);
                int homeworkPercent = int.Parse(studentInfo[6]);
                int projectPercent = int.Parse(studentInfo[7]);
                int midtermPercent = int.Parse(studentInfo[8]);
                int finalPercent = int.Parse(studentInfo[9]);

                // Not ortalaması ağırlıklara göre hesaplanır.
                float avarage = ((homeworkGrade * homeworkPercent) / 100) + ((projectGrade * projectPercent) / 100) + ((midtermGrade * midtermPercent) / 100) + ((finalGrade * finalPercent) / 100);
                
                //Sınıf ortalamasına eklenir.
                classAvarage += avarage;

                //Not ortalamasına ait harf notu bulunur.
                string gradeLetter = findGradeLetter(avarage);
                
                //ilgili harf notlarına göre ilgili harf notundaki öğrenci sayısı 1 arttırılır.
                if (gradeLetter.Equals("AA"))
                {
                    countAA += 1;
                } 
                else if (gradeLetter.Equals("BA"))
                {
                    countBA += 1;
                } 
                else if (gradeLetter.Equals("BB"))
                {
                    countBB += 1;
                } 
                else if (gradeLetter.Equals("CB"))
                {
                    countCB += 1;
                }
                else if (gradeLetter.Equals("CC"))
                {
                    countCC += 1;
                }
                else if (gradeLetter.Equals("DC"))
                {
                    countDC += 1;
                }
                else if (gradeLetter.Equals("DD"))
                {
                    countDD += 1;
                }
                else if (gradeLetter.Equals("FD"))
                {
                    countFD += 1;
                }
                else if (gradeLetter.Equals("FF"))
                {
                    countFF += 1;
                }
                else if (gradeLetter.Equals("KALDI"))
                {
                    countEKSIK += 1;
                }

                // Sonuç dosyasına ilgili bilgiler yazılır.
                fileData += name + " " + studentNumber + " " + avarage.ToString() + " " + gradeLetter +  Environment.NewLine;

            }

            Console.WriteLine("Öğrenci harf notları hesaplanma işlemi bitti.");

            Console.WriteLine("Sınıf ortalaması hesaplanıyor...");

            // Sınıf ortalaması hesaplanır.
            classAvarage = classAvarage / students.Length;
            Console.WriteLine("Sınıf ortalaması hesaplandı.");

            // Derse ait harf notu bilgileri dosyaya yazılmak için derlenir.
            fileData += "AA" + "--" + countAA + Environment.NewLine;

            fileData += "BA" + "--" + countBA + Environment.NewLine;

            fileData += "BB" + "--" + countBB + Environment.NewLine;

            fileData += "CB" + "--" + countCB + Environment.NewLine;

            fileData += "CC" + "--" + countCC + Environment.NewLine;

            fileData += "DC" + "--" + countDC + Environment.NewLine;

            fileData += "DD" + "--" + countDD + Environment.NewLine;

            fileData += "FD" + "--" + countFD + Environment.NewLine;

            fileData += "FD" + "--" + countFD + Environment.NewLine;

            fileData += "KALDI" + "--" + countEKSIK + Environment.NewLine;


            // tüm bilgiler dosyaya yazılır.
            File.WriteAllText(resultFileName, fileData);

            Console.WriteLine("Derse ait bilgiler " + resultFileName + " dosyasına kaydedildi. Çıkış yapmak için bir tuşa basın.");

            Console.ReadLine();
        }

        /*
         * Verilen ortalamaya ait harf notunu bulur ve geriye dönderir.
         */
        static string findGradeLetter (float avarage)
        {

            if (avarage >= 90 && avarage <= 100)
            {
                return "AA";
            } 
            else if (avarage >= 85 && avarage < 90) 
            {
                return "BA";
            } 
            else if (avarage >= 80 && avarage < 85)
            {
                return "BB";
            } 
            else if (avarage >= 75 && avarage < 80)
            {
                return "CB";
            } 
            else if (avarage >= 65 && avarage < 75)                                  
            {
                return "CC";
            }
            else if (avarage >= 58 && avarage < 65)
            {
                return "DC";
            }
            else if (avarage >= 50 && avarage < 58)
            {
                return "DD";
            }
            else if (avarage >= 40 && avarage < 50)
            {
                return "FD";
            }
            else if (avarage >= 0 && avarage < 40)
            {
                return "FF";
            }
            

            return "KALDI";
        }
    }
}
