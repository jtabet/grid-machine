﻿using System;
using System.Collections.Generic;
using System.IO;

namespace GridMachine.Services
{
    public class HtmlWriter : Writer
    {
        private readonly string OutputDirectory = "./output";

        /// <summary>
        /// Writes a grid into an html file
        /// </summary>
        /// <param name="grid"></param>
        public void Write(IEnumerable<IEnumerable<bool>> grid)
        {
            using (FileStream fileStream = new FileStream(string.Format(@"{0}/{1}.html", OutputDirectory, Guid.NewGuid()), FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine("<html><body><table style='border-collapse: collapse;border: 1px solid black;'>");

                    foreach (IEnumerable<bool> row in grid)
                    {
                        streamWriter.WriteLine("<tr>");

                        foreach (bool isBlack in row)
                        {
                            if (isBlack)
                            {
                                streamWriter.WriteLine("<td style='background-color:black;border: 1px solid black;'>&nbsp;&nbsp;&nbsp;&nbsp;");
                            }
                            else
                            {
                                streamWriter.WriteLine("<td style='background-color:white;border: 1px solid black;'>&nbsp;&nbsp;&nbsp;&nbsp;");
                            }

                            streamWriter.WriteLine("</td>");
                        }

                        streamWriter.WriteLine("</tr>");
                    }

                    streamWriter.WriteLine("</table></body></html>");
                }
            }
        }
    }
}
