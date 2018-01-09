using System;
using System.Collections.Generic;

public class JsonData
{
    public string module { get; set; }
    public string type { get; set; }
    public DateTime datetime { get; set; }
    public Payload payload { get; set; }

    public override string ToString()
    {
        List<string> ret = new List<string>();

        if (this.module != null)
        {
            ret.Add("module: " + this.module);
        }

        ret.Add("type: " + this.type);
        ret.Add("datetime: " + this.datetime.ToString());

        if (this.payload != null)
        {
            ret.Add("payload: ");
            ret.Add(this.payload.ToString());
        }

        return string.Join("\n", ret.ToArray());
    }
}

public class Payload
{
    public List<Channel> channels { get; set; }
    public string error { get; set; }
    public string detail { get; set; }

    public override string ToString()
    {
        List<string> ret = new List<string>();

        if (this.error != null)
        {
            ret.Add("error: " + this.error);
        }
        
        if (this.detail != null)
        {
            ret.Add("detail: " + this.detail);
        }

        if (this.channels != null)
        {
            ret.Add("channels: ");

            foreach (var ch in this.channels)
            {
                ret.Add("channel: ");
                ret.Add(ch.ToString());
            }
        }

        return string.Join("\n",ret.ToArray());
    }
}

public class Channel
{
    public int channel { get; set; }
    public string type { get; set; }
    public double value { get; set; }
    public DateTime datetime { get; set; }

    public override string ToString()
    {
        List<string> ret = new List<string>();

        ret.Add("channel: " + this.channel);
        ret.Add("type: " + this.type);
        ret.Add("value: " + this.value);
        ret.Add("datetime: " + this.datetime);

        return string.Join("\n", ret.ToArray());
    }
}
