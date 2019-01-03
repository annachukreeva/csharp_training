using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbooktests
{
   public class GroupHelper : HelperBase
    {
      
        public GroupHelper(ApplicationManager manager) 
            : base (manager)
        {
        }

       public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(v);
            DeleteGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public GroupHelper RemoveGroups(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroupNew(group.Id);
            DeleteGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public GroupHelper SelectGroupNew(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this; 
        }


        // public GroupHelper Remove(GroupData group)
        // {
        //    manager.Navigator.GoToGroupsPage();

        //   SelectGroup(group);
        //  DeleteGroup();
        //  manager.Navigator.ReturnToGroupPage();
        //  return this;

        // }



        private List<GroupData> groupCache = null; 


        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
              }
            }
            string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
            string[] parts = allGroupNames.Split('\n');
            int shift = groupCache.Count - parts.Length;
            for (int i = 0; i < groupCache.Count; i++)
            {
                if (i < shift)
                {
                    groupCache[i].Name = "";
                }
                else
                {
                    groupCache[i].Name = parts[i - shift].Trim();
                }
            }
         return new List<GroupData>(groupCache);
        }

       

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupFormin(newData);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }


        public GroupHelper Modify(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup2(group.Id);
            InitGroupModification();
            FillGroupFormin(group);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public GroupHelper SelectGroup2(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and  @vlaue='"+id+"'])")).Click();
            //driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupFormin(group);
            SubmitGroupCreation();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public int GetGroupCount()
        {
           return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupFormin(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }              

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
       // public GroupHelper ReturnToGroupPage()
       //{
         //   driver.FindElement(By.LinkText("group page")).Click();
         //   driver.FindElement(By.LinkText("Logout")).Click();
         //   return this;
       // }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            //driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        private GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
