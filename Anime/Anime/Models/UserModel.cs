using Anime.DataServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anime.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public DateTime BDay { get; set; }
        public string Sex { get; set; }
        public string AboutMe { get; set; }
        public string ImgUrl { get; set; }

        public UserModel() { }

        private readonly int id;
        private void SetModel()
        {
            var data = (UserModel)DataService.GetData(DataType.User, id);

            this.Name = data.Name;
            this.BDay = data.BDay;
            this.Sex = data.Sex;
            this.AboutMe = data.AboutMe;
            this.ImgUrl = data.ImgUrl;
        }
        public UserModel(int user_id)
        {
            this.id = user_id;
            SetModel();
        }

        public void UpdateModelWithType(DataType type, object newValue)
        {
            DataService.UpdateData(type, this.id, newValue);

            switch (type) {
                case DataType.UserName:
                    this.Name = newValue.ToString();
                    break;
                case DataType.UserSex:
                    this.BDay = (DateTime)newValue;
                    break;
                case DataType.UserBDay:
                    this.Sex = newValue.ToString();
                    break;
                case DataType.UserAboutMe:
                    this.AboutMe = newValue.ToString();
                    break;
                case DataType.UserImgUrl:
                    this.ImgUrl = newValue.ToString();
                    break;
                default:
                    throw new Exception("error type");
            }
        }
    }
}
