using Server.DTO;
using Server.DTO.Send;
using Server.entities;
using Server.Models;
using Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class UserController
    {
        private UserModel userModel = new UserModel();

        public SendData<UserDTO> login(UserLogin userLogin)
        {
            string username = userLogin.username;
            string password = userLogin.password;

            UserEntity found = userModel.findByUsername(username);

            if(found == null) 
                return new SendData<UserDTO>(Actions.LOGIN,"User không tồn tại", new UserDTO());

            bool isMatch = BCrypt.Net.BCrypt.Verify(password, found.password);
            if(!isMatch)
                return new SendData<UserDTO>(Actions.LOGIN, "Mật khẩu không đúng", new UserDTO());

            SendData<UserDTO> result = new SendData<UserDTO>(Actions.LOGGED, Message.SUCCESS, new UserDTO(found.id, found.username));
            result.setFlags();

            return result;
        }

        public SendData<UserDTO> logged()
        {
            SendData<UserDTO> result = new SendData<UserDTO>(Actions.LOGGED, Message.ERROR, new UserDTO());
            return result;
        }

        public SendData<UserDTO> register(UserEntity userEntity)
        {
            string username = userEntity.username;
            string password = userEntity.password;
            string bankCardID = userEntity.bankCardID;

            if (!checkUsername(username))
                return new SendData<UserDTO>(Actions.REGISTER, "Username gom it nhat 5 ky tu, a-z, 0-9.", new UserDTO());
            if (!checkPasword(password))
                return new SendData<UserDTO>(Actions.REGISTER, "Password gom it nhat 3 ky tu.", new UserDTO());
            if (!checkBankCardID(bankCardID))
                return new SendData<UserDTO>(Actions.REGISTER, "Ma the ngan hang phai gom 10 ky tu so.", new UserDTO());

            UserEntity doseExists = userModel.findByUsername(username);
            if(doseExists != null)
                new SendData<UserDTO>(Actions.REGISTER, "Username da ton tai.", new UserDTO());

            string hash = BCrypt.Net.BCrypt.HashPassword(password);

            UserEntity newUserEntity = new UserEntity(username, hash, bankCardID);

            if(userModel.create(newUserEntity) == 0)
            {
                return new SendData<UserDTO>(Actions.REGISTER, Message.ERROR, new UserDTO());
            }

            SendData<UserDTO> result = new SendData<UserDTO>(Actions.REGISTER, Message.SUCCESS, new UserDTO());
            result.setFlags();

            return result;
        }

        private bool checkUsername(string username)
        {
            string pattern = @"^[a-z0-9]{0,5}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(username))
            {
                return false;
            }
            return true;
        }
        private bool checkPasword(string password)
        {
            if (password.Length < 3)
                return false;
            return true;
        }
        private bool checkBankCardID(string bankCardID)
        {
            string pattern = @"^[0-9]{1,10}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(bankCardID))
            {
                return false;
            }
            return true;
        }
    }
}
