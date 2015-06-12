using System;
using System.Linq;

namespace TheSlum.GameEngine
{
    using GameObject.Characters;
    using GameObject.Items;
    using GameObject.Items.Bonus;

    class EngineExtension : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    throw new NotImplementedException("Command is not implemented!");
            }
        }
        protected override void CreateCharacter(string[] inputParams)
        {
            Character newCharacter;
            string characterClass = inputParams[1];
            string characterID = inputParams[2];
            int coordinateX;
            int coordinateY;
            bool validXCoordinates = int.TryParse(inputParams[3], out coordinateX);
            bool validYCoordinates = int.TryParse(inputParams[4], out coordinateY);
            if (!validXCoordinates && !validYCoordinates)
            {
                throw new FormatException("Incorect coordinates!");
            }
            Team team = (Team)Enum.Parse(typeof(Team), inputParams[5]);
            switch (characterClass)
            {
                case "mage":
                    newCharacter = new Mage(characterID, coordinateX, coordinateY, team);
                    break;
                case "warrior":
                    newCharacter = new Warrior(characterID, coordinateX, coordinateY, team);
                    break;
                case "healer":
                    newCharacter = new Healer(characterID, coordinateX, coordinateY, team);
                    break;
                default: throw new NotImplementedException("Character is not implemented!");
            }
            characterList.Add(newCharacter);
        }
        protected new void AddItem(string[] inputParams)
        {
            string characterID = inputParams[1];
            string itemClass = inputParams[2];
            string itemID = inputParams[3];
            Item newItem;
            Character character = characterList.Where(x => x.Id == characterID).FirstOrDefault();
            switch (itemClass)
            {
                case "axe":
                    newItem = new Axe(itemID);
                    break;
                case "shield":
                    newItem = new Shield(itemID);
                    break;
                case "injection":
                    newItem = new Injection(itemID);
                    break;
                case "pill":
                    newItem = new Pill(itemID);
                    break;
                default: throw new NotImplementedException("Item is not implemented!");
            }
            character.AddToInventory(newItem);
        }

    }
}
