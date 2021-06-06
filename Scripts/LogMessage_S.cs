using System.Xml;

public class MinEventActionLogMessage : MinEventActionBase
{
    string command;
    public override void Execute(MinEventParams _params)
    {

        if (command == null)
        {
            LogAnywhere.Log(string.Format($"Error: Command == null"));
            return;
        }
        else
        {

            if (!SingletonMonoBehaviour<ConnectionManager>.Instance.IsClient)
            {
                LogAnywhere.Log(string.Format($"Message = {command}"));
            }
            else
            {
                //SingletonMonoBehaviour<ConnectionManager>.Instance.SendToServer(NetPackageManager.GetPackage<NetPackageConsoleCmdServer>().Setup(GameManager.Instance.World.GetPrimaryPlayerId(), command), false);
            }
        }
    }

    //public override bool ParseXmlAttribute(XmlAttribute _attribute)
    //{
    //    bool xmlAttribute = base.ParseXmlAttribute(_attribute);
    //    if (xmlAttribute || !(_attribute.Name == "command"))
    //    {
    //        LogAnywhere.Log(string.Format($"xmlAtrribute = {xmlAttribute}, _attribute.Name = {_attribute.Name}"));
    //        return xmlAttribute;
    //    }
    //    LogAnywhere.Log(string.Format($"xmlAtrribute = {xmlAttribute}, _attribute.Name = {_attribute.Name}"));
    //    command = _attribute.Value;
    //    return true;
    //}

    public override bool ParseXmlAttribute(XmlAttribute _attribute)
    {
        if (_attribute.Name == "command")
        {
            LogAnywhere.Log(string.Format($"Attribute = {_attribute.Name}, _attribute.Value = {_attribute.Value}"));
            command = _attribute.Value;

            return true;
        }
        LogAnywhere.Log(string.Format($"Passint to base.  Attribute = {_attribute.Name}, _attribute.Value = {_attribute.Value}"));
        return base.ParseXmlAttribute(_attribute);
    }


}


