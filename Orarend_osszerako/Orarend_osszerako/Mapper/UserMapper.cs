using System.Collections.Generic;
using Orarend_osszerako.Model;

namespace Orarend_osszerako.Mapper
{
    public static class UserMapper
    {
        /// <summary>
        /// UserModel típust konvertál Model típusra (entitás)
        /// </summary>
        /// <param name="user">Átkonvertálandó UserModel</param>
        /// <returns>User-ré konvertált UserModel</returns>
        public static User ModelToEntity(UserModel user)
        {
            User newEntityUser = new User();
            newEntityUser.Id = user.UserId;
            newEntityUser.FirstName = user.FirstName;
            newEntityUser.LastName = user.LastName;
            newEntityUser.UserName = user.UserName;
            newEntityUser.Password = user.Password;
            newEntityUser.LastLogin = user.LastLogin;
            //newEntityUser.Subjects = SubjectMapper.ModelCollectionToEntityCollection(user.Subjects);
            //newEntityUser.Timetables = TimetableMapper.ModelCollectionToEntityCollection(user.Timetables);
            return newEntityUser;
        }
        /// <summary>
        /// User típust (entitás) konvertál UserModel típusra
        /// </summary>
        /// <param name="user">Átkonvertálandó User (entitás)</param>
        /// <returns>UserModel-é konvertált User</returns>
        public static UserModel EntityToModel(User user)
        {
            UserModel newModelUser = new UserModel();
            newModelUser.UserId = user.Id;
            newModelUser.FirstName = user.FirstName;
            newModelUser.LastName = user.LastName;
            newModelUser.UserName = user.UserName;
            newModelUser.Password = user.Password;
            newModelUser.LastLogin = user.LastLogin;
            //newModelUser.Subjects = SubjectMapper.EntityCollectionToModelCollection(user.Subjects);
            //newModelUser.Timetables = TimetableMapper.EntityCollectionToModelCollection(user.Timetables);
            return newModelUser;
        }
        /// <summary>
        /// Egy UserModel típusú kollekciót konvertál User típusú kollekcióra (entitások)
        /// </summary>
        /// <param name="userCollection">UserModel típusú kollekció</param>
        /// <returns>User típusú kollekció (entitások)</returns>
        public static ICollection<User> UserCollectionToEntityUserCollection(ICollection<UserModel> userCollection)
        {
            HashSet<User> userModelCollection = new HashSet<User>();
            foreach (UserModel item in userCollection)
            {
                userModelCollection.Add(ModelToEntity(item));
            }
            return userModelCollection;
        }
        /// <summary>
        /// Egy User típusú kollekciót konvertál UserModel típusú kollekcióra (entitások)
        /// </summary>
        /// <param name="userCollection">User típusú kollekció (entitások)</param>
        /// <returns>UserModel típusú kollekció (entitások)</returns>
        public static ICollection<UserModel> EntityUserCollectionToUserCollection(ICollection<User> userCollection)
        {
            HashSet<UserModel> entityModelCollection = new HashSet<UserModel>();
            foreach (User item in userCollection)
            {
                entityModelCollection.Add(EntityToModel(item));
            }
            return entityModelCollection;
        }
    }
}
