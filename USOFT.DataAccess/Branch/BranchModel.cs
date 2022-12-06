﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using Usoft.Common.CommonFunction;

namespace USOFT.DataAccess.Branch
{
    public class BranchModel
    {
        USOFTEntities db = new USOFTEntities();
        CommonFunction cf = new CommonFunction();
        public List<Object> GetBranch(string searchvalue,string ddl,int page,int pageSize)
        {
            Users.UserLogOn log = new Users.UserLogOn();
            ObjectParameter pointTotalPage = new ObjectParameter("pointTotalPage", typeof(int));
            ObjectParameter pointTotalData = new ObjectParameter("pointTotalData", typeof(int));
            List<spBranchList_Result> row = db.spBranchList(cf.SearchText(ddl,searchvalue),page,pageSize,pointTotalPage,pointTotalData).ToList();
            List<Object> obj = new List<object>();
            obj.Add(row);
            obj.Add(pointTotalPage.Value);
            obj.Add(pointTotalData.Value);
            return obj;
        }

        public List<spBranchView_Result> getBranchResult(int value)
        {
            List<spBranchView_Result> row = db.spBranchView(value).ToList();
            return row;
            
        }
        public void editBranch(int branchId,string branchCode,string branchName,int branchType, int? branchParent,string branchAddress,string branchPhone,bool isActive,string inputID)
        {
            db.spBranchUpdate(branchId, branchCode, branchName, branchType, branchParent, branchAddress, branchPhone, isActive, inputID);
        }
        public void insertBranch(int branchId,string branchCode,string branchName,int branchType, int? branchParent,string branchAddress,string branchPhone,bool isActive,string inputID)
        {
            db.spBranchInsert(branchId, branchCode, branchName, branchType, branchParent, branchAddress, branchPhone, isActive, inputID);
        }
    }
}
