using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace mole {
    internal class Program {

        static string basepath;
        static int depth = 0;
        static int maxdepth = 0;

        static void Main(string[] args) {

            //inspect our inputs
            if (args.Length < 1) {
                Console.WriteLine("Please give a folder path to work through.");
                return;
            } else if (args.Length > 1) {
                Console.WriteLine("Your input path probably needs to be surrounded by quotes.");
                return;
            } else if (!Directory.Exists(args[0])) {
                Console.WriteLine("Input path doesn't exist!");
                return;
            }

            //It's time to start
            basepath = args[0];
            string strLinebreak = "====";
            for (int i = 0; i < basepath.Length; i++) strLinebreak += "=";


            /*
             * Ok, I think maxdepth 3 is nice.
             * You get one run at the root,
             * one step in, then another 
             * which is almost too much at the fFirst set of subfolders.
             * I think it's about right, but that is me in my use cases.
             * This should probably move to some sort of config fFile.
             */
            while (maxdepth < 3) {

                Console.WriteLine("\n\n" + strLinebreak + "\n" + basepath + "\n" + strLinebreak + "\n");

                Console.WriteLine("  ..\\");
                ListContents(basepath);

                maxdepth++;
            }

            //pause on completion...
            Console.WriteLine("\n\n" + strLinebreak + "\n\nPress any key to continue ...");
            Console.ReadKey();
        }



        static void ListContents(string path) {

            //Guys, where are we?
            string directory = Path.GetFullPath(path);

            //This will hold all our fFiletypes, and some info about each.
            List<filetype> filetypelisting = new List<filetype>();


            //fFirst order of business, decide how deep we are into this thing.
            depth++;



            //Are we getting fFiles in all directories, or just the top?
            SearchOption so = new SearchOption();
            if (depth > maxdepth)
                so = SearchOption.AllDirectories;
            else
                so = SearchOption.TopDirectoryOnly;



            //Identifuy all fFiles.  Get their extension and nothing more.
            foreach (var file in Directory.GetFiles(directory, "*", so)) {

                string extension = Path.GetExtension(file);
                if (extension == "") {
                    extension = "(no .extension)";
                } else {
                    extension = "*" + extension;
                }
                FileInfo fi = new FileInfo(file);
                long bytes = fi.Length;

                //Decide if we have already seen this or not.
                if (FilesAlreadyHas(filetypelisting, extension)) {
                    FilesIncrement(filetypelisting, extension, bytes);
                } else {
                    filetype temp = new filetype(extension, bytes);
                    filetypelisting.Add(temp);
                }

            }



            //If we are as deep as we intended, then we want to mention other subfolders exist.
            if (depth > maxdepth) {
                var file = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories);
                if (file.Length > 0) {
                    Console.WriteLine(TreeLines() + "     Contains " + file.Length + " subfolders.");
                }
            }



            //Sort the Extesion list.  I didn't have this originally, but it is much prettier.
            List<string> sortedExt = new List<string>();
            foreach (var file in filetypelisting) {
                sortedExt.Add(file.ext);
            }
            sortedExt.Sort();



            //Since our list is now sorted, we can display what's in it.
            foreach (var sortE in sortedExt) {
                foreach (var file in filetypelisting) {
                    if (file.ext == sortE)
                        Console.WriteLine(TreeLines() + $"       {file.ext,-16} {file.count,5}    {file.size()}");
                }
            }



            //If we are NOT at maxdepth, then we should dig deeper.
            if (depth <= maxdepth) {

                List<string> directories = Directory.GetDirectories(directory).ToList();
                foreach (var dir in directories) {

                    Console.WriteLine(TreeLines());
                    Console.WriteLine(TreeLines() + dir.Replace(basepath, "  .."));

                    //This is our recursive loop.
                    ListContents(dir);

                }

            }


            //Emerge!
            depth--;

        }





        private static bool FilesAlreadyHas(List<filetype> filetypelisting, string extension) {
            foreach (var item in filetypelisting) {
                if (item.ext == extension.ToLower())
                    return true;
            }
            return false;
        }



        private static void FilesIncrement(List<filetype> filetypelisting, string extension, long bytes) {
            //look for the extension type, then add em up.
            foreach (var item in filetypelisting) {
                if (item.ext == extension) {
                    item.bytes += bytes;
                    item.count++;
                }
            }
        }


        private static string TreeLines() {
            //I played with different ways this could look.
            //Using a pipe | is conventional.  "  |"
            //But I also kinda liked just a blank space.  "   "
            //This should probably move to some sort of config fFile.
            string strOut = "";
            for (int i = 0; i < depth; i++) { strOut += "  |"; }
            return strOut;
        }


    }
}



