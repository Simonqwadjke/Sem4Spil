using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DataAccessLayer;
using ModelLayer;
using ModelLayer.Units;
using ModelLayer.Buildings;
using ModelLayer.Buildings.Defense;
using ModelLayer.Buildings.Passive;

namespace ApplicationServer
{
    public class Manager
    {
        private MD5 md5 = MD5.Create();
        private SessionManager sessionmgr = SessionManager.getInstance();

        public User CreateUser(User user)
        {
            bool success = false;
            user.Garison = GenerateUnits();
            user.Map = GenerateMap();
            user.Ranking = 0;
            user.Level = 1;
            user.Upgrades = new Upgrades(0, 0, 0);
            user.Password = PasswordHashing(user.Password);

            if (new DBUser().CreateUser(user))
            {
                if (SaveData(user))
                {
                    success = true;
                }
            }
            if (!success)
            {
                user = null;
            }


            return user;
        }

        public User Login(User user)
        {
            MD5 md5 = MD5.Create();
            Console.WriteLine("Login Attempt for " + user.Username);
            user.Password = PasswordHashing(user.Password);
            user = new DBUser().Login(user, sessionmgr.createSession());
            if (user != null)
            {
                new DBUnit().GetUserUnits(user);
                new DBBattles().GetUserBattles(user);
                new DBUpgrade().GetUserUpgrades(user);
                new DBInvaders().GetUserInvaders(user);
                new DBBuilding().GetUserBuildings(user);
            }

            return user;
        }

        public bool SaveData(User user)
        {
            bool success = false, partSuccess = true;

            if (new DBUser().GetUser(user.Username) != null && sessionmgr.checkSession(user.Session))
            {
                if (user.Garison != null)
                {
                    if (!new DBUnit().SaveUserUnits(user))
                    {
                        partSuccess = false;
                    }
                }
                if (user.Map != null)
                {
                    if (!new DBBuilding().SaveUserBuildings(user))
                    {
                        partSuccess = false;
                    }
                }
                if (user.Upgrades != null)
                {
                    if (!new DBUpgrade().SaveUserUpgrades(user))
                    {
                        partSuccess = false;
                    }
                }
                if (partSuccess)
                {
                    success = true;
                }
            }

            return success;
        }

        public bool SaveBattle(Battle battle)
        {
            bool success = false;

            if (new DBBattles().SaveBattle(battle))
            {
                success = true;
            }

            return success;
        }

        public Map FetchMap(User user)
        {
            Map map = null;

            if (new DBBuilding().GetUserBuildings(user))
            {
                map = user.Map;
            }

            return map;
        }

        private string PasswordHashing(string password)
        {
            Byte[] input = Encoding.ASCII.GetBytes(password);
            Byte[] hash = md5.ComputeHash(input);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private List<Group> GenerateUnits()
        {
            List<Group> list = new List<Group>();
            list.Add(new Group());
            for (int i = 0; i < 2; i++)
            {
                Rifleman rifle = new Rifleman();
                rifle.Accuricy = 10;
                rifle.Armor = 1;
                rifle.AttackSpeed = 5;
                rifle.Damage = 12;
                rifle.HitPoints = 100;
                rifle.Range = 1000;
                rifle.Speed = 20;
                rifle.UnitSize = 1;

                list[0].units.Add(rifle);
            }
            return list;
        }

        private Map GenerateMap()
        {
            Map map = new Map();

            Building build = new HeadQuarters();
            build.Armor = 5;
            build.HitPoints = 800;
            build.Level = 1;
            build.Location = new Location(0, 15);
            build.Size = new Size(5, 5);
            map.Buildinds.Add(build);

            build = new IronMine();
            build.Armor = 3;
            build.HitPoints = 200;
            build.Level = 1;
            build.Location = new Location(5, 15);
            build.Size = new Size(5, 5);
            map.Buildinds.Add(build);

            build = new SawMill();
            build.Armor = 3;
            build.HitPoints = 200;
            build.Level = 1;
            build.Location = new Location(10, 15);
            build.Size = new Size(5, 5);
            map.Buildinds.Add(build);

            build = new Labratory();
            build.Armor = 2;
            build.HitPoints = 400;
            build.Level = 1;
            build.Location = new Location(15, 15);
            build.Size = new Size(4, 4);
            map.Buildinds.Add(build);

            build = new GatlingTurret();
            build.Armor = 8;
            build.HitPoints = 350;
            build.Level = 1;
            build.Location = new Location(3, 5);
            build.Size = new Size(3, 3);
            map.Buildinds.Add(build);

            build = new GatlingTurret();
            build.Armor = 8;
            build.HitPoints = 350;
            build.Level = 1;
            build.Location = new Location(15, 5);
            build.Size = new Size(3, 3);
            map.Buildinds.Add(build);

            build = new Cannon();
            build.Armor = 10;
            build.HitPoints = 500;
            build.Level = 1;
            build.Location = new Location(9, 5);
            build.Size = new Size(3, 3);
            map.Buildinds.Add(build);

            build = new Wall();
            build.Armor = 20;
            build.HitPoints = 150;
            build.Level = 1;
            build.Location = new Location(3, 2);
            build.Size = new Size(1, 1);
            map.Buildinds.Add(build);

            build = new Wall();
            build.Armor = 20;
            build.HitPoints = 150;
            build.Level = 1;
            build.Location = new Location(6, 2);
            build.Size = new Size(1, 1);
            map.Buildinds.Add(build);

            build = new Wall();
            build.Armor = 20;
            build.HitPoints = 150;
            build.Level = 1;
            build.Location = new Location(9, 2);
            build.Size = new Size(1, 1);
            map.Buildinds.Add(build);

            build = new Wall();
            build.Armor = 20;
            build.HitPoints = 150;
            build.Level = 1;
            build.Location = new Location(12, 2);
            build.Size = new Size(1, 1);
            map.Buildinds.Add(build);

            build = new Wall();
            build.Armor = 20;
            build.HitPoints = 150;
            build.Level = 1;
            build.Location = new Location(15, 2);
            build.Size = new Size(1, 1);
            map.Buildinds.Add(build);

            build = new Wall();
            build.Armor = 20;
            build.HitPoints = 150;
            build.Level = 1;
            build.Location = new Location(18, 2);
            build.Size = new Size(1, 1);
            map.Buildinds.Add(build);

            return map;
        }
    }
}
