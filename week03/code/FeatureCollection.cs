using System.Runtime.Versioning;

public class FeatureCollection
{
    public Feature[] Features {get; set;}

}

public class Feature 

{
    public string Place {get; set;}
    public double Mag {get; set;}
}
