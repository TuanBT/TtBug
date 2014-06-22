using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BugProject
{
    public class MidiPlayer
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        private static extern long mciSendString(string lpstrCommand, string lpstrreturnString, long ureturnLength, long hwndCallback);

        private string file;
        string pathFile = Environment.SystemDirectory[0].ToString() + ":" + @"\Users\Public\" + "sound.mid";

        public MidiPlayer(string strFileName)
        {
            this.file = strFileName;
        }

        public MidiPlayer(byte[] resourceFileName)
        {
            try
            {
                if (File.Exists(pathFile))
                {
                    File.Delete(pathFile);
                }
                File.WriteAllBytes(pathFile, resourceFileName);
                this.file = pathFile;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public bool PlaySound()
        {
            long lRet = -1;
            try
            {
                if (File.Exists(this.file))
                {
                    lRet = mciSendString("stop midi", "", 0, 0);
                    lRet = mciSendString("close midi", "", 0, 0);
                    lRet = mciSendString(("open sequencer!"
                                          + (file + " alias midi")), "", 0, 0);
                    lRet = mciSendString("play midi", "", 0, 0);
                    //return lRet;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public bool StopSound(bool deleteFile)
        {
            try
            {
                mciSendString("close all", "", 0, 0);
                //Có muốn xóa file không
                if (deleteFile)
                {
                    try
                    {
                        File.Delete(this.file);
                    }
                    catch (Exception ex)
                    {
                        
                       Console.WriteLine(ex);
                    }
                    
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
