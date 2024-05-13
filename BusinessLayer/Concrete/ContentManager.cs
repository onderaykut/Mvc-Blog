﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            
             _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            
              _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
            // _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
            // _contentDal.Update(content);
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
            // return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> GetList(string p)
        {    
            return _contentDal.List(x=>x.ContentValue.Contains(p));
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }
    }
}
