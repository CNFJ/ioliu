using ioliu.data;
using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public class InImgRepository : IImgServers<Img>
    {
        private readonly IoliuContext ioliuContext;

        public InImgRepository(IoliuContext ioliuContext)
        {
            this.ioliuContext = ioliuContext;
        }

        public async Task<Img> AddImg(Img newModel)
        {
            var result =await ioliuContext.imgs.AddAsync(newModel);
            
           ioliuContext.SaveChanges();
           
            return newModel;
        }

        public IEnumerable<Img> GetImgAll()
        {
            var imgModel= ioliuContext.imgs.ToList();
            return imgModel;
        }

        public IEnumerable<Img> GetImgGroup(string GroupName)
        {
            var imgModel = ioliuContext.imgs.Where(i=>i.GroupName==GroupName);
            return imgModel;
        }

        public Img GetImgID(string id)
        {
            var img = ioliuContext.imgs.Find(id);
            return img;
        }
    }
}
