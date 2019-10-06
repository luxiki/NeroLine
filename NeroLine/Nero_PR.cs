using System;
using Nero_BL_namespace;
using Nero_Wiev;

namespace Nero_PR_namespace
{
    class Nero_PR
    {
        private readonly IForm iform;
        private readonly INero_BL ibl;
       

        public Nero_PR(IForm form,INero_BL bL )
        {
            iform = form;
            ibl = bL;
            
            iform.FileOpen += Iform_FileOpen;
            iform.FileSave += Iform_FileSave;
            iform.AddSmd += Iform_AddSmd;
        }

        private void Iform_AddSmd(object sender, EventArgString e)
        {
           
            iform.SetMsg ( ibl.AddSmd("line"+e.strArg1,e.strArg2,e.strArg3));
           
        }

        private void Iform_FileSave(object sender, EventArgs e)
        {
            string s = "line"+Convert.ToString(iform.GetNeroLine());
            
            iform.SetMsg(ibl.SaveFile(s));

        }

        private void Iform_FileOpen(object sender, EventArgs e)
        {
            bool isOpen = false;
            string s = ibl.CheckFile(iform.FilePath, ref isOpen);
            //s = "hh";
            iform.SetMsg(s);
            iform.SetButSaveFile(isOpen);
        }
    }
}
