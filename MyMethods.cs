using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.AI;
using Gaia;
using UnityEngine.UI;

public class Functions
{
    public enum MaleNames {Morlotus, Williacheek, Cheekrussell, Nind, Stinkmoore, Wallacestomp, Thudblaese, Bagjenkins, Hundor, Adanator, Ellishu, Robertsievous, Smithslight, Jenkinsoddy, Drogharper, Kelleyphire, Coopertrouble}
    public enum FemaleNames {Tukora, Thudreynolds, Williafirebreatha, Dracogher, Reeriona, Cheekblack, Spencerievous, Hunknee, Magicberts, Droghayes, Stoshu, Greenner, Mischiearnold, Wattspop, Rhaelson, Payneg, Ruizcheek, Suxia, Forestgarcia}

    public static MaleNames[] MaleNamePool=new MaleNames[] {MaleNames.Morlotus, MaleNames.Williacheek, MaleNames.Cheekrussell, MaleNames.Nind, MaleNames.Stinkmoore, MaleNames.Wallacestomp, MaleNames.Thudblaese, MaleNames.Bagjenkins, MaleNames.Hundor, MaleNames.Adanator, MaleNames.Ellishu, MaleNames.Robertsievous, MaleNames.Smithslight, MaleNames.Jenkinsoddy, MaleNames.Drogharper, MaleNames.Kelleyphire, MaleNames.Coopertrouble};
    public static FemaleNames[] FemaleNamePool=new FemaleNames[] {FemaleNames.Tukora, FemaleNames.Thudreynolds, FemaleNames.Williafirebreatha, FemaleNames.Dracogher, FemaleNames.Reeriona, FemaleNames.Cheekblack, FemaleNames.Spencerievous, FemaleNames.Hunknee, FemaleNames.Magicberts, FemaleNames.Droghayes, FemaleNames.Stoshu, FemaleNames.Greenner, FemaleNames.Mischiearnold, FemaleNames.Wattspop, FemaleNames.Rhaelson, FemaleNames.Payneg, FemaleNames.Ruizcheek, FemaleNames.Suxia, FemaleNames.Forestgarcia};

    public static Item.ItemType[] RandomItems=new Item.ItemType[] {Item.ItemType.Coin, Item.ItemType.Iron, Item.ItemType.Copper, Item.ItemType.Steel, Item.ItemType.Leather, Item.ItemType.Skin, Item.ItemType.Apple, Item.ItemType.Bread, Item.ItemType.Meat, Item.ItemType.BasicHealPotion, Item.ItemType.HealPotion, Item.ItemType.DraughtOfBalancePotion, Item.ItemType.Gold, Item.ItemType.Wood, Item.ItemType.Stone, Item.ItemType.Mushroom, Item.ItemType.Potato, Item.ItemType.CopperTrap, Item.ItemType.SteelTrap, Item.ItemType.WoodenTrap, Item.ItemType.IronTrap};


    public static Quest RandomQuest(int id, string vName) // id-> Villager ID vName -> Villager Name
    {
        int reqCount=Random.Range(1, 10);  // requirement quantity
        int rewCount=Random.Range(1, 10);  // reward quantity
        Item requirement=RandomItem(reqCount);
        Item reward=RandomItem(rewCount);
        

        if(reward.Type==requirement.Type)  // If they are the same it won't make any sense
        {
            return RandomQuest(id, vName);
        }
        if(((reward.Value*rewCount) <= (requirement.Value*reqCount)) || ((reward.Value*rewCount) > (requirement.Value*reqCount*5))) // Value is the price of the item
        {
            return RandomQuest(id, vName);
        }
        string qName="Bring "+requirement.Name;  // Quest name
        string description="You have promised some "+requirement.Name+" to "+vName;

        var quest= new FindQuest(requirement, reward, id, vName, qName, description);  //Items has their quantity in their classes
        quest.Town=TownManager.CurrentVillage.Town; // Quest location
        return quest;
    }

    public static Item RandomItem(int count)
    {
        return NewItem(RandomItems[Random.Range(0, RandomItems.Length)], count);
    }

    public static Item NewItem(Item.ItemType item, int num)
    {

        Item returnItem=new Item();

        //Debug.Log("Item: "+item+" count: "+num);
        
        switch(item)
        {
            
            case Item.ItemType.Coin:
            returnItem= new Coin(num);
            break;
            

            case Item.ItemType.Iron:
            returnItem= new Iron(num);
            break;
            

            case Item.ItemType.Copper:
            returnItem= new Copper(num);
            break;
            

            case Item.ItemType.Steel:
            returnItem= new Steel(num);
            break;
            

            case Item.ItemType.Leather:
            returnItem= new Leather(num);
            break;
            

            case Item.ItemType.Skin:
            returnItem=new Skin(num);
            break;
            

            case Item.ItemType.Timber:
            returnItem= new Timber(num);
            break;
            

            case Item.ItemType.Stone:
            returnItem= new Stone(num);
            break;
            

            case Item.ItemType.Wood:
            returnItem= new Wood(num);
            break;
            

            case Item.ItemType.Apple:
            returnItem= new Apple(num);
            break;
            

            case Item.ItemType.Bread:
            returnItem= new Bread(num);
            break;
            

            case Item.ItemType.Meat:
            returnItem= new Meat(num);
            break;
            

            case Item.ItemType.Potato:
            returnItem= new Potato(num);
            break;
            

            case Item.ItemType.Anise:
            returnItem= new Anise(num);
            break;
            

            case Item.ItemType.Angelica:
            returnItem= new Angelica(num);
            break;
            

            case Item.ItemType.Kanika:
            returnItem= new Kanika(num);
            break;
            

            case Item.ItemType.GiantsFodder:
            returnItem= new GiantsFodder(num);
            break;
            

            case Item.ItemType.GiantsGrass:
            returnItem= new GiantsGrass(num);
            break;
            

            case Item.ItemType.StoneHazel:
            returnItem= new StoneHazel(num);
            break;
            

            case Item.ItemType.AutumnRoot:
            returnItem= new AutumnRoot(num);
            break;
            

            case Item.ItemType.ArrowRods:
            returnItem= new ArrowRods(num);
            break;
            

            case Item.ItemType.DevilClaw:
            returnItem= new DevilClaw(num);
            break;
            

            case Item.ItemType.StarCress:
            returnItem= new StarCress(num);
            break;
            

            case Item.ItemType.SheepBane:
            returnItem= new SheepBane(num);
            break;
            

            case Item.ItemType.KingsOrchid:
            returnItem= new KingsOrchid(num);
            break;
            

            case Item.ItemType.CurlyFinger:
            returnItem= new CurlyFinger(num);
            break;
            

            case Item.ItemType.Basil:
            returnItem= new Basil(num);
            break;
            

            case Item.ItemType.VoidStone:
            returnItem= new VoidStone();
            break;
            

            case Item.ItemType.EnhancedBladeHilt:
            returnItem= new EnhancedBladeHilt();
            break;
            

            case Item.ItemType.ShieldOfTheFallenKnight:
            returnItem= new ShieldOfTheFallenKnight();
            break;
            

            case Item.ItemType.OldChandelier:
            returnItem= new OldChandelier();
            break;
            

            case Item.ItemType.BoneDust:
            returnItem= new BoneDust();
            break;
            

            case Item.ItemType.SomeGuysHead:
            returnItem= new SomeGuysHead();
            break;
            

            case Item.ItemType.SomeGuysDiadem:
            returnItem= new SomeGuysDiadem();
            break;
            

            case Item.ItemType.VileDust:
            returnItem= new VileDust();
            break;
            

            case Item.ItemType.Bone:
            returnItem= new Bone();
            break;
            

            case Item.ItemType.IronScraps:
            returnItem= new IronScraps();
            break;
            

            case Item.ItemType.UndeadBlood:
            returnItem= new UndeadBlood();
            break;
            

            case Item.ItemType.BucketOfWater:
            returnItem= new BucketOfWater();
            break;
            

            case Item.ItemType.Wheat:
            returnItem= new Wheat(num);
            break;
            

            case Item.ItemType.Milk:
            returnItem= new Milk(num);
            break;
            

            case Item.ItemType.Soup:
            returnItem= new Soup(num);
            break;
            

            case Item.ItemType.MeatStew:
            returnItem= new MeatStew(num);
            break;
            

            case Item.ItemType.DrumStick:
            returnItem= new DrumStick(num);
            break;
            

            case Item.ItemType.Cheese:
            returnItem= new Cheese(num);
            break;
            

            case Item.ItemType.Berry:
            returnItem= new Berry(num);
            break;
            

            case Item.ItemType.Mushroom:
            returnItem= new Mushroom(num);
            break;
            

            case Item.ItemType.Gold:
            returnItem= new Gold(num);
            break;

            case Item.ItemType.IronTrap:
            returnItem= new IronTrap(num);
            break;

            case Item.ItemType.CopperTrap:
            returnItem= new CopperTrap(num);
            break;

            case Item.ItemType.WoodenTrap:
            returnItem= new WoodenTrap(num);
            break;

            case Item.ItemType.SteelTrap:
            returnItem= new SteelTrap(num);
            break;
            

            case Item.ItemType.DemonicIngot:
            returnItem= new DemonicIngot(num);
            break;

            case Item.ItemType.Graditude:
            returnItem= new Graditude();
            break;

            case Item.ItemType.Unknown:
            returnItem= new Unknown();
            break;

            case Item.ItemType.RottenMeat:
            returnItem= new RottenMeat(num);
            break;

            

            default:
            Debug.Log(item+num+" couldn't find!!!");
            returnItem= new Potato(100);
            break;
            
        }
        return returnItem;

    }

    public static GameObject FindClosest(GameObject[] Serie, GameObject Ref)
    {
        float Distance=10000;
        GameObject closest=null;
        for(int i=0; i<Serie.Length; i++)
        {
            if((Serie[i].transform.position-Ref.transform.position).sqrMagnitude<Distance)
            {
                Distance=(Serie[i].transform.position-Ref.transform.position).sqrMagnitude;
                closest=Serie[i];
            }
        }
        return closest;
    }

    public static IEnumerator Take(Transform Object, Transform HandTarget, Rig rig, Transform Hand)    // Hand is a child of hand bone, hand's child(0) is the handle position. Rig's child(0) has the two bone IK constraint (Root -> R.Arm Mid -> RForeArm -> Tip -> R.Hand Source ->HandTarget) 
    {
        bool handed=false;
        HandTarget.position=Object.position;
        while(rig.weight<1)
        {
            rig.weight+=0.045f;
            if(!handed && rig.weight>0.95)
            {
                handed=true;
                Object.SetParent(Hand, true);
                Object.position=Hand.GetChild(0).position;
            }

            yield return new WaitForSeconds(0.015f);
            
        }
        Object.localPosition=Object.GetChild(0).localPosition;
        Object.localEulerAngles=Object.GetChild(0).localEulerAngles;
        while(rig.weight>0)
        {
            rig.weight-=0.045f;

            yield return new WaitForSeconds(0.015f);
            
        }
        yield break;
    }
    public static IEnumerator Put(Transform Place, Transform Object, Transform HandTarget, Rig rig, Transform Hand)
    {
        rig.weight=0;
        bool put=false;
        HandTarget.position=Place.GetChild(0).position;
        while(rig.weight<1)
        {
            rig.weight+=0.045f;
            if(!put && rig.weight>0.95)
            {
                put=true;
                Object.SetParent(null, true);
                Object.position=Hand.GetChild(0).position;
            }

            yield return new WaitForSeconds(0.015f);
            
        }
        Object.position=Place.GetChild(0).position;

        while(rig.weight>0)
        {
            rig.weight-=0.045f;

            yield return new WaitForSeconds(0.015f);
            
        }
        

    }
    
    public static Transform FindParentWithName(string Name, Transform Self)
    {
        Transform Parent=Self;

        while(Parent.parent.name!=Name)
        {
            Parent=Parent.parent;
        }
        return Parent.parent;
    }
    public static Transform FindParentWithTag(string Tag, Transform Self)
    {
        Transform Parent=Self;

        while(Parent.parent.tag!=Tag)
        {
            Parent=Parent.parent;
        }
        return Parent.parent;
    }

    public static IEnumerator IncreaseRutin() // Mouse text is the instruction text (static variable), scales when mouse on an item, mouse text's parent's child(1) is the place, holds instrution's background so it will scale up with the lines
    {
        Transform obj=ItemSpriteManager.MouseText.transform.parent;
        Text _text= ItemSpriteManager.MouseText;
        float num=0.22f;
        int lineCount=_text.text.Split('\n').Length-1;
        lineCount+= _text.text.Length / 29;
        num+=lineCount*0.15f;

        obj.GetChild(0).localScale=new Vector3(1, num, 1);
        while(obj.localScale.x<1 && !ItemSpriteManager.Down)
        {
            obj.localScale+=new Vector3(0.04f, 0.04f, 0.04f);
            yield return new WaitForSecondsRealtime(0.001f);
        }
    }

    public static IEnumerator DecreaseRutin()
    {
        while(ItemSpriteManager.MouseText.transform.parent.localScale.x>0 && ItemSpriteManager.Down)
        {
            ItemSpriteManager.MouseText.transform.parent.localScale-=new Vector3(0.04f, 0.04f, 0.04f);
            if(ItemSpriteManager.MouseText.transform.parent.localScale.x<=0)
            {
                ItemSpriteManager.MouseText.transform.parent.localScale=Vector3.zero;
                break;
            } 
            ItemSpriteManager.MouseText.transform.parent.localScale=Vector3.zero;
            yield return new WaitForSecondsRealtime(0.001f);
        }
    }


    public static string ReturnRichnessName(Seller.Richness richness)
    {
        string str="";
        switch(richness)
        {
            case Seller.Richness.Miserable:
            str="Miserable";
            break;
            case Seller.Richness.VeryPoor:
            str="Very Poor";
            break;
            case Seller.Richness.Poor:
            str="Poor";
            break;
            case Seller.Richness.Avarage:
            str="Avarage";
            break;
            case Seller.Richness.AboveAvarage:
            str="Above Avarage";
            break;
            case Seller.Richness.Rich:
            str="Rich";
            break;
            case Seller.Richness.VeryRich:
            str="Very Rich";
            break;
        }
        return str;
    }

    public static void SetBlackSmithQuality(Seller.Richness richness, BlackSmithManager blackSmith)
    {
        switch(richness)
        {
            case Seller.Richness.Miserable:
            blackSmith.qualityLevel=0;
            break;
            case Seller.Richness.VeryPoor:
            blackSmith.qualityLevel=1;
            break;
            case Seller.Richness.Poor:
            blackSmith.qualityLevel=2;
            break;
            case Seller.Richness.Avarage:
            blackSmith.qualityLevel=3;
            break;
            case Seller.Richness.AboveAvarage:
            blackSmith.qualityLevel=4;
            break;
            case Seller.Richness.Rich:
            blackSmith.qualityLevel=5;
            break;
            case Seller.Richness.VeryRich:
            blackSmith.qualityLevel=6;
            break;
        }
        
    }

    public static IEnumerator Sit(Rig rig, Transform target, Transform sitPos) // Rig's child has multi position constraint (constraint -> root)
    {
        Vector3 pos=sitPos.position;
        Transform self=rig.transform.parent;
        WaitForSeconds wait=new WaitForSeconds(0.01f);
        Vector3 temp=new Vector3(pos.x, self.position.y, pos.z);
        temp=temp+SitPos.forward;
        Vector3 tempLook=SitPos.parent.GetChild(1).position+SitPos.forward*2;
        tempLook.y=self.position.y;
        while(true)
        {
            self.position=Vector3.Lerp (self.position, temp, 0.05f);
            if((self.position-temp).sqrMagnitude<1) break;

            yield return wait;
        }
        
        self.position=temp;
        
        
        self.LookAt(tempLook);

        target.position=pos;
        while(true)
        {
            rig.weight+=0.08f;
            target.position=pos;
            if(rig.weight==1) break;

            yield return wait;
        }
        yield break;
    }

    public static void Informate(Vector3 pos, string description)
    {
        TextMesh temp=Stock.InfoText;
        pos.y+=2;

        Transform tempTransform=temp.transform.parent;
        tempTransform.gameObject.SetActive(true);

        temp.text=description;
        tempTransform.position=pos;

        tempTransform.LookAt(ItemSpriteManager.Sprites.MainCamera.position);
    }

    

    public static void Arm(MeshRenderer sword, MeshRenderer shield, Transform self)
    {
        var animator=self.GetComponent<Animator>();

        animator.SetTrigger("Arm");

        sword.enabled=true;
        shield.enabled=true;

    }

    public static IEnumerator Disarm(MeshRenderer sword, MeshRenderer shield, Transform self)
    {
        var animator=self.GetComponent<Animator>();

        animator.SetTrigger("Disarm");

        yield return new WaitForSeconds(1f);

        sword.enabled=false;
        shield.enabled=false;

        yield break;

    }

    public static void Talk(Transform self, AudioClip clip)
    {
        ItemSpriteManager.Sprites.StartCoroutine(SpeakRoutine(self, clip));
    }

    public static IEnumerator SpeakRoutine(Transform self, AudioClip clip)
    {
        Source=Store.SpeakSource.GetComponent<AudioSource>();
        Animator animator=self.GetComponent<Animator>();

        animator.SetTrigger("Talk");
        source.PlayOneShot(clip);

        yield return new WaitForSeconds(clip.length);

        animator.SetTrigger("Idle");
        yield break;
    }
}

