using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public static class BAL
    {
        public static List<Folders> GetFolders(int ID)
        {
            return DAL.DAL.GetFolders(ID);
        }
        public static int CreateFolder(int ID, string Name)
        {
            return DAL.DAL.CreateFolder( ID, Name);
        }
        public static int ReturnParent(int Child)
        {
            if (Child == 0) {
                return 0;
            }
            return DAL.DAL.ReturnParent(Child);
        }
    }
}
