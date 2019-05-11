using System;
using System.Collections.Generic;
using System.IO;

namespace GridMachine.Services
{
    public class HtmlWriter : Writer
    {
        /// <summary>
        /// Writes a grid into an html file
        /// </summary>
        /// <param name="grid"></param>
        public void Write(IEnumerable<IEnumerable<bool>> grid)
        {
            using (FileStream fileStream = new FileStream(string.Format(@"{0}.html", Guid.NewGuid()), FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine("<html><body><table>");

                    foreach (IEnumerable<bool> row in grid)
                    {
                        streamWriter.WriteLine("<tr>");

                        foreach (bool isBlack in row)
                        {
                            if (isBlack)
                            {
                                streamWriter.WriteLine("<td style='background-color:black'>&nbsp;&nbsp;&nbsp;&nbsp;");
                            }
                            else
                            {
                                streamWriter.WriteLine("<td style='background-color:lightgrey'>&nbsp;&nbsp;&nbsp;&nbsp;");
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
