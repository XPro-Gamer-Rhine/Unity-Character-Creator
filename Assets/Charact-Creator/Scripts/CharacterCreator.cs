using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.AssetBundles;
using UnityEngine.UI;
using UMA.CharacterSystem;
using Boo.Lang.Environments;
using System.IO;
public class CharacterCreator : MonoBehaviour
{
    public DynamicCharacterAvatar avatar;
    public Dictionary<string, DnaSetter> dna;
    public float drag = 20f;



    [Header("Slider Names")]

    public Slider skinGreennessSlider;
    public Slider skinBluenessSlider;
    public Slider skinRednessSlider;
    public Slider heightSlider;
    public Slider headSizeSlider;
    public Slider headWidthSlider;
    public Slider neckThicknessSlider;
    public Slider armLengthSlider;
    public Slider forearmLengthSlider;
    public Slider armWidthSlider;
    public Slider forearmWidthSlider;
    public Slider handsSizeSlider;
    public Slider feetSizeSlider;
    public Slider legSeparationSlider;
    public Slider upperMuscleSlider;
    public Slider lowerMuscleSlider;
    public Slider upperWeightSlider;
    public Slider lowerWeightSlider;
    public Slider legsSizeSlider;
    public Slider bellySlider;
    public Slider waistSlider;
    public Slider gluteusSizeSlider;
    public Slider earsSizeSlider;
    public Slider earsPositionSlider;
    public Slider earsRotationSlider;
    public Slider noseSizeSlider;
    public Slider noseCurveSlider;
    public Slider noseWidthSlider;
    public Slider noseInclinationSlider;
    public Slider nosePositionSlider;
    public Slider nosePronouncedSlider;
    public Slider noseFlattenSlider;
    public Slider chinSizeSlider;
    public Slider chinPronouncedSlider;
    public Slider chinPositionSlider;
    public Slider mandibleSizeSlider;
    public Slider jawsSizeSlider;
    public Slider jawsPositionSlider;
    public Slider cheekSizeSlider;
    public Slider cheekPositionSlider;
    public Slider lowCheekPronouncedSlider;
    public Slider lowCheekPositionSlider;
    public Slider foreheadSizeSlider;
    public Slider foreheadPositionSlider;
    public Slider lipsSizeSlider;
    public Slider mouthSizeSlider;
    public Slider eyeRotationSlider;
    public Slider eyeSizeSlider;
    public Slider breastSizeSlider;
    public Slider eyeSpacingSlider;

    
    public string myRecipe;


    public List<string> hairModelsMale = new List<string>();
    private int currentHairModelMale;

    public List<string> hairModelsFemale = new List<string>();
    private int currentHairModelFemale;

    public List<string> ChestModelsMale = new List<string>();
    private int currentChestModelMale;

    public List<string> ChestModelsFemale = new List<string>();
    private int currentChestModelFemale;

    public List<string> LegsModelsMale = new List<string>();
    private int currentLegsModelMale;

    public List<string> LegsModelsFemale = new List<string>();
    private int currentLegsModelFemale;

    public List<string> FeetModelsMale = new List<string>();
    private int currentFeetModelMale;

    public List<string> FeetModelsFemale = new List<string>();
    private int currentFeetModelFemale;

    void OnEnable()
    {
        avatar.CharacterUpdated.AddListener(Updated);
        skinGreennessSlider.onValueChanged.AddListener(skinGreennessChange);
        skinBluenessSlider.onValueChanged.AddListener(skinBluenessChange);
        skinRednessSlider.onValueChanged.AddListener(skinRednessChange);
        heightSlider.onValueChanged.AddListener(HeightChange);
        headSizeSlider.onValueChanged.AddListener(headSizeChange);
        headWidthSlider.onValueChanged.AddListener(headWidthChange);
        neckThicknessSlider.onValueChanged.AddListener(neckThicknessChange);
        armLengthSlider.onValueChanged.AddListener(armLengthChange);
        forearmLengthSlider.onValueChanged.AddListener(forearmLengthChange);
        armWidthSlider.onValueChanged.AddListener(armWidthChange);
        forearmWidthSlider.onValueChanged.AddListener(forearmWidthChange);
        handsSizeSlider.onValueChanged.AddListener(handsSizeChange);
        feetSizeSlider.onValueChanged.AddListener(feetSizeChange);
        legSeparationSlider.onValueChanged.AddListener(legSeparationChange);
        upperMuscleSlider.onValueChanged.AddListener(upperMuscleChange);
        lowerMuscleSlider.onValueChanged.AddListener(lowerMuscleChange);
        upperWeightSlider.onValueChanged.AddListener(upperWeightChange);
        lowerWeightSlider.onValueChanged.AddListener(lowerWeightChange);
        legsSizeSlider.onValueChanged.AddListener(legsSizeChange);
        bellySlider.onValueChanged.AddListener(BellyChange);
        waistSlider.onValueChanged.AddListener(waistChange);
        gluteusSizeSlider.onValueChanged.AddListener(gluteusSizeChange);
        earsSizeSlider.onValueChanged.AddListener(earsSizeChange);
        earsPositionSlider.onValueChanged.AddListener(earsPositionChange);
        earsRotationSlider.onValueChanged.AddListener(earsRotationChange);
        noseSizeSlider.onValueChanged.AddListener(noseSizeChange);
        noseCurveSlider.onValueChanged.AddListener(noseCurveChange);
        noseWidthSlider.onValueChanged.AddListener(noseWidthChange);
        noseInclinationSlider.onValueChanged.AddListener(noseInclinationChange);
        nosePositionSlider.onValueChanged.AddListener(nosePositionChange);
        nosePronouncedSlider.onValueChanged.AddListener(nosePronouncedChange);
        noseFlattenSlider.onValueChanged.AddListener(noseFlattenChange);
        chinSizeSlider.onValueChanged.AddListener(chinSizeChange);
        chinPronouncedSlider.onValueChanged.AddListener(chinPronouncedChange);
        chinPositionSlider.onValueChanged.AddListener(chinPositionChange);
        mandibleSizeSlider.onValueChanged.AddListener(mandibleSizeChange);
        jawsSizeSlider.onValueChanged.AddListener(jawsSizeChange);
        jawsPositionSlider.onValueChanged.AddListener(jawsPositionChange);
        cheekSizeSlider.onValueChanged.AddListener(cheekSizeChange);
        cheekPositionSlider.onValueChanged.AddListener(cheekPositionChange);
        lowCheekPronouncedSlider.onValueChanged.AddListener(lowCheekPronouncedChange);
        lowCheekPositionSlider.onValueChanged.AddListener(lowCheekPositionChange);
        foreheadSizeSlider.onValueChanged.AddListener(foreheadSizeChange);
        foreheadPositionSlider.onValueChanged.AddListener(foreheadPositionChange);
        lipsSizeSlider.onValueChanged.AddListener(lipsSizeChange);
        mouthSizeSlider.onValueChanged.AddListener(mouthSizeChange);
        eyeRotationSlider.onValueChanged.AddListener(eyeRotationChange);
        eyeSizeSlider.onValueChanged.AddListener(eyeSizeChange);
        breastSizeSlider.onValueChanged.AddListener(breastSizeChange);
        eyeSpacingSlider.onValueChanged.AddListener(eyeSpacingChange);
        
    }
    private void OnDisable()
    {
        avatar.CharacterUpdated.RemoveListener(Updated);
        skinGreennessSlider.onValueChanged.RemoveListener(skinGreennessChange);
        skinBluenessSlider.onValueChanged.RemoveListener(skinBluenessChange);
        skinRednessSlider.onValueChanged.RemoveListener(skinRednessChange);
        heightSlider.onValueChanged.RemoveListener(HeightChange);
        headSizeSlider.onValueChanged.RemoveListener(headSizeChange);
        headWidthSlider.onValueChanged.RemoveListener(headWidthChange);
        neckThicknessSlider.onValueChanged.RemoveListener(neckThicknessChange);
        armLengthSlider.onValueChanged.RemoveListener(armLengthChange);
        forearmLengthSlider.onValueChanged.RemoveListener(forearmLengthChange);
        armWidthSlider.onValueChanged.RemoveListener(armWidthChange);
        forearmWidthSlider.onValueChanged.RemoveListener(forearmWidthChange);
        handsSizeSlider.onValueChanged.RemoveListener(handsSizeChange);
        feetSizeSlider.onValueChanged.RemoveListener(feetSizeChange);
        legSeparationSlider.onValueChanged.RemoveListener(legSeparationChange);
        upperMuscleSlider.onValueChanged.RemoveListener(upperMuscleChange);
        lowerMuscleSlider.onValueChanged.RemoveListener(lowerMuscleChange);
        upperWeightSlider.onValueChanged.RemoveListener(upperWeightChange);
        lowerWeightSlider.onValueChanged.RemoveListener(lowerWeightChange);
        legsSizeSlider.onValueChanged.RemoveListener(legsSizeChange);
        bellySlider.onValueChanged.RemoveListener(BellyChange);
        waistSlider.onValueChanged.RemoveListener(waistChange);
        gluteusSizeSlider.onValueChanged.RemoveListener(gluteusSizeChange);
        earsSizeSlider.onValueChanged.RemoveListener(earsSizeChange);
        earsPositionSlider.onValueChanged.RemoveListener(earsPositionChange);
        earsRotationSlider.onValueChanged.RemoveListener(earsRotationChange);
        noseSizeSlider.onValueChanged.RemoveListener(noseSizeChange);
        noseCurveSlider.onValueChanged.RemoveListener(noseCurveChange);
        noseWidthSlider.onValueChanged.RemoveListener(noseWidthChange);
        noseInclinationSlider.onValueChanged.RemoveListener(noseInclinationChange);
        nosePositionSlider.onValueChanged.RemoveListener(nosePositionChange);
        nosePronouncedSlider.onValueChanged.RemoveListener(nosePronouncedChange);
        noseFlattenSlider.onValueChanged.RemoveListener(noseFlattenChange);
        chinSizeSlider.onValueChanged.RemoveListener(chinSizeChange);
        chinPronouncedSlider.onValueChanged.RemoveListener(chinPronouncedChange);
        chinPositionSlider.onValueChanged.RemoveListener(chinPositionChange);
        mandibleSizeSlider.onValueChanged.RemoveListener(mandibleSizeChange);
        jawsSizeSlider.onValueChanged.RemoveListener(jawsSizeChange);
        jawsPositionSlider.onValueChanged.RemoveListener(jawsPositionChange);
        cheekSizeSlider.onValueChanged.RemoveListener(cheekSizeChange);
        cheekPositionSlider.onValueChanged.RemoveListener(cheekPositionChange);
        lowCheekPronouncedSlider.onValueChanged.RemoveListener(lowCheekPronouncedChange);
        lowCheekPositionSlider.onValueChanged.RemoveListener(lowCheekPositionChange);
        foreheadSizeSlider.onValueChanged.RemoveListener(foreheadSizeChange);
        foreheadPositionSlider.onValueChanged.RemoveListener(foreheadPositionChange);
        lipsSizeSlider.onValueChanged.RemoveListener(lipsSizeChange);
        mouthSizeSlider.onValueChanged.RemoveListener(mouthSizeChange);
        eyeRotationSlider.onValueChanged.RemoveListener(eyeRotationChange);
        eyeSizeSlider.onValueChanged.RemoveListener(eyeSizeChange);
        breastSizeSlider.onValueChanged.RemoveListener(breastSizeChange);
        eyeSpacingSlider.onValueChanged.RemoveListener(eyeSpacingChange);
    }
    public void SwitchGender(bool male)
    {
        if (male && avatar.activeRace.name != "HumanMaleDCS")
            avatar.ChangeRace("HumanMaleDCS");
        if (!male && avatar.activeRace.name != "HumanFemaleDCS")
            avatar.ChangeRace("HumanFemaleDCS");
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Space))
        {
            DragCharacter();
        }
    }


    void Updated(UMAData data)
    {
        dna = avatar.GetDNA();
        skinGreennessSlider.value = dna["skinGreenness"].Get();
        skinBluenessSlider.value = dna["skinBlueness"].Get();
        skinRednessSlider.value = dna["skinRedness"].Get();
        heightSlider.value = dna["height"].Get();
        headSizeSlider.value = dna["headSize"].Get();
        headWidthSlider.value = dna["headWidth"].Get();
        neckThicknessSlider.value = dna["neckThickness"].Get();
        armLengthSlider.value = dna["armLength"].Get();
        forearmLengthSlider.value = dna["forearmLength"].Get();
        armWidthSlider.value = dna["armWidth"].Get();
        forearmWidthSlider.value = dna["forearmWidth"].Get();
        handsSizeSlider.value = dna["handsSize"].Get();
        feetSizeSlider.value = dna["feetSize"].Get();
        legSeparationSlider.value = dna["legSeparation"].Get();
        upperMuscleSlider.value = dna["upperMuscle"].Get();
        lowerMuscleSlider.value = dna["lowerMuscle"].Get();
        upperWeightSlider.value = dna["upperWeight"].Get();
        lowerWeightSlider.value = dna["lowerWeight"].Get();
        legsSizeSlider.value = dna["legsSize"].Get();
        bellySlider.value = dna["belly"].Get();
        waistSlider.value = dna["waist"].Get();
        gluteusSizeSlider.value = dna["gluteusSize"].Get();
        earsSizeSlider.value = dna["earsSize"].Get();
        earsPositionSlider.value = dna["earsPosition"].Get();
        earsRotationSlider.value = dna["earsRotation"].Get();
        noseSizeSlider.value = dna["noseSize"].Get();
        noseCurveSlider.value = dna["noseCurve"].Get();
        noseWidthSlider.value = dna["noseWidth"].Get();
        noseInclinationSlider.value = dna["noseInclination"].Get();
        nosePositionSlider.value = dna["nosePosition"].Get();
        nosePronouncedSlider.value = dna["nosePronounced"].Get();
        noseFlattenSlider.value = dna["noseFlatten"].Get();
        chinSizeSlider.value = dna["chinSize"].Get();
        chinPronouncedSlider.value = dna["chinPronounced"].Get();
        chinPositionSlider.value = dna["chinPosition"].Get();
        mandibleSizeSlider.value = dna["mandibleSize"].Get();
        jawsSizeSlider.value = dna["jawsSize"].Get();
        jawsPositionSlider.value = dna["jawsPosition"].Get();
        cheekSizeSlider.value = dna["cheekSize"].Get();
        cheekPositionSlider.value = dna["cheekPosition"].Get();
        lowCheekPronouncedSlider.value = dna["lowCheekPronounced"].Get();
        lowCheekPositionSlider.value = dna["lowCheekPosition"].Get();
        foreheadSizeSlider.value = dna["foreheadSize"].Get();
        foreheadPositionSlider.value = dna["foreheadPosition"].Get();
        lipsSizeSlider.value = dna["lipsSize"].Get();
        mouthSizeSlider.value = dna["mouthSize"].Get();
        eyeRotationSlider.value = dna["eyeRotation"].Get();
        eyeSizeSlider.value = dna["eyeSize"].Get();
        breastSizeSlider.value = dna["breastSize"].Get();
        eyeSpacingSlider.value = dna["eyeSpacing"].Get();
        
    }

    
    

    public void skinGreennessChange(float val)
    {
        dna["skinGreenness"].Set(val);
        avatar.BuildCharacter();
    }

    public void skinBluenessChange(float val)
    {
        dna["skinBlueness"].Set(val);
        avatar.BuildCharacter();
    }

    public void skinRednessChange(float val)
    {
        dna["skinRedness"].Set(val);
        avatar.BuildCharacter();
    }
    public void HeightChange(float val)
    {
        dna["height"].Set(val);
        avatar.BuildCharacter();
    }

    public void headSizeChange(float val)
    {
        dna["headSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void headWidthChange(float val)
    {
        dna["headWidth"].Set(val);
        avatar.BuildCharacter();
    }
    public void neckThicknessChange(float val)
    {
        dna["neckThickness"].Set(val);
        avatar.BuildCharacter();
    }
    public void armLengthChange(float val)
    {
        dna["armLength"].Set(val);
        avatar.BuildCharacter();
    }
    public void forearmLengthChange(float val)
    {
        dna["forearmLength"].Set(val);
        avatar.BuildCharacter();
    }
    public void armWidthChange(float val)
    {
        dna["armWidth"].Set(val);
        avatar.BuildCharacter();
    }
    public void forearmWidthChange(float val)
    {
        dna["forearmWidth"].Set(val);
        avatar.BuildCharacter();
    }

    public void handsSizeChange(float val)
    {
        dna["handsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void feetSizeChange(float val)
    {
        dna["feetSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void legSeparationChange(float val)
    {
        dna["legSeparation"].Set(val);
        avatar.BuildCharacter();
    }
    public void upperMuscleChange(float val)
    {
        dna["upperMuscle"].Set(val);
        avatar.BuildCharacter();
    }
    public void lowerMuscleChange(float val)
    {
        dna["lowerMuscle"].Set(val);
        avatar.BuildCharacter();
    }
    public void upperWeightChange(float val)
    {
        dna["upperWeight"].Set(val);
        avatar.BuildCharacter();
    }
    public void lowerWeightChange(float val)
    {
        dna["lowerWeight"].Set(val);
        avatar.BuildCharacter();
    }
    public void legsSizeChange(float val)
    {
        dna["legsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void BellyChange(float val)
    {
        dna["belly"].Set(val);
        avatar.BuildCharacter();
    }

    public void waistChange(float val)
    {
        dna["waist"].Set(val);
        avatar.BuildCharacter();
    }
    public void gluteusSizeChange(float val)
    {
        dna["gluteusSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void earsSizeChange(float val)
    {
        dna["earsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void earsPositionChange(float val)
    {
        dna["earsPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void earsRotationChange(float val)
    {
        dna["earsRotation"].Set(val);
        avatar.BuildCharacter();
    }
    public void noseSizeChange(float val)
    {
        dna["noseSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void noseCurveChange(float val)
    {
        dna["noseCurve"].Set(val);
        avatar.BuildCharacter();
    }
    public void noseWidthChange(float val)
    {
        dna["noseWidth"].Set(val);
        avatar.BuildCharacter();
    }
    public void noseInclinationChange(float val)
    {
        dna["noseInclination"].Set(val);
        avatar.BuildCharacter();
    }
    public void nosePositionChange(float val)
    {
        dna["nosePosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void nosePronouncedChange(float val)
    {
        dna["nosePronounced"].Set(val);
        avatar.BuildCharacter();
    }
    public void noseFlattenChange(float val)
    {
        dna["noseFlatten"].Set(val);
        avatar.BuildCharacter();
    }
    public void chinSizeChange(float val)
    {
        dna["chinSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void chinPronouncedChange(float val)
    {
        dna["chinPronounced"].Set(val);
        avatar.BuildCharacter();
    }
    public void chinPositionChange(float val)
    {
        dna["chinPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void mandibleSizeChange(float val)
    {
        dna["mandibleSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void jawsSizeChange(float val)
    {
        dna["jawsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void jawsPositionChange(float val)
    {
        dna["jawsPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void cheekSizeChange(float val)
    {
        dna["cheekSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void cheekPositionChange(float val)
    {
        dna["cheekPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void lowCheekPronouncedChange(float val)
    {
        dna["lowCheekPronounced"].Set(val);
        avatar.BuildCharacter();
    }
    public void lowCheekPositionChange(float val)
    {
        dna["lowCheekPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void foreheadSizeChange(float val)
    {
        dna["foreheadSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void foreheadPositionChange(float val)
    {
        dna["foreheadPosition"].Set(val);
        avatar.BuildCharacter();
    }
    public void lipsSizeChange(float val)
    {
        dna["lipsSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void mouthSizeChange(float val)
    {
        dna["mouthSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void eyeRotationChange(float val)
    {
        dna["eyeRotation"].Set(val);
        avatar.BuildCharacter();
    }
    public void eyeSizeChange(float val)
    {
        dna["eyeSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void breastSizeChange(float val)
    {
        dna["breastSize"].Set(val);
        avatar.BuildCharacter();
    }
    public void eyeSpacingChange(float val)
    {
        dna["eyeSpacing"].Set(val);
        avatar.BuildCharacter();
    }




    public void ChangeSkinColor(Color col)
    {
        avatar.SetColor("Skin", col);
        avatar.UpdateColors(true);
    }

    void DragCharacter()
    {
        float rotX = Input.GetAxis("Mouse X") * drag * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * drag * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        //transform.RotateAround(Vector3.right, rotY);
    }
    public void ChangeHair(bool plus)
    {
        if (avatar.activeRace.name == "HumanMaleDCS")
        {
            if (plus)
                currentHairModelMale++;
            else
                currentHairModelMale--;

            currentHairModelMale = Mathf.Clamp(currentHairModelMale, 0, hairModelsMale.Count - 1);

            if (hairModelsMale[currentHairModelMale] == "None")
            {
                avatar.ClearSlot("Hair");
            }
            else
            {
                avatar.SetSlot("Hair", hairModelsMale[currentHairModelMale]);
            }
        }
        if (avatar.activeRace.name == "HumanFemaleDCS")
        {
            if (plus)
                currentHairModelFemale++;
            else
                currentHairModelFemale--;

            currentHairModelFemale = Mathf.Clamp(currentHairModelFemale, 0, hairModelsFemale.Count - 1);

            if (hairModelsFemale[currentHairModelFemale] == "None")
            {
                avatar.ClearSlot("Hair");
            }
            else
            {
                avatar.SetSlot("Hair", hairModelsFemale[currentHairModelFemale]);
            }
        }


        avatar.BuildCharacter();
    }

    public void SaveRecipe()
    {
        myRecipe = avatar.GetCurrentRecipe();
        File.WriteAllText(Application.persistentDataPath + "/save.txt", myRecipe);
    }

    public void LoadRecipe()
    {
        myRecipe = File.ReadAllText(Application.persistentDataPath + "/save.txt");
        avatar.ClearSlots();
        avatar.LoadFromRecipeString(myRecipe);
    }

    public void ChangeCloths(bool plus)
    {
        if (avatar.activeRace.name == "HumanMaleDCS")
        {
            if (plus)
                currentChestModelMale++;
            else
                currentChestModelMale--;

            currentChestModelMale = Mathf.Clamp(currentChestModelMale, 0, ChestModelsMale.Count - 1);

            if (ChestModelsMale[currentChestModelMale] == "None")
            {
                avatar.ClearSlot("Chest");
            }
            else
            {
                avatar.SetSlot("Chest", ChestModelsMale[currentChestModelMale]);
            }
        }
        if (avatar.activeRace.name == "HumanFemaleDCS")
        {
            if (plus)
                currentChestModelFemale++;
            else
                currentChestModelFemale--;

            currentChestModelFemale = Mathf.Clamp(currentChestModelFemale, 0, ChestModelsFemale.Count - 1);

            if (ChestModelsFemale[currentChestModelFemale] == "None")
            {
                avatar.ClearSlot("Chest");
            }
            else
            {
                avatar.SetSlot("Chest", ChestModelsFemale[currentChestModelFemale]);
            }
        }


        avatar.BuildCharacter();
    }




    public void ChangePants(bool plus)
    {
        if (avatar.activeRace.name == "HumanMaleDCS")
        {
            if (plus)
                currentLegsModelMale++;
            else
                currentLegsModelMale--;

            currentLegsModelMale = Mathf.Clamp(currentLegsModelMale, 0, LegsModelsMale.Count - 1);

            if (LegsModelsMale[currentLegsModelMale] == "None")
            {
                avatar.ClearSlot("Legs");
            }
            else
            {
                avatar.SetSlot("Legs", LegsModelsMale[currentLegsModelMale]);
            }
        }
        if (avatar.activeRace.name == "HumanFemaleDCS")
        {
            if (plus)
                currentLegsModelFemale++;
            else
                currentLegsModelFemale--;

            currentLegsModelFemale = Mathf.Clamp(currentLegsModelFemale, 0, LegsModelsFemale.Count - 1);

            if (LegsModelsFemale[currentLegsModelFemale] == "None")
            {
                avatar.ClearSlot("Legs");
            }
            else
            {
                avatar.SetSlot("Legs", LegsModelsFemale[currentLegsModelFemale]);
            }
        }


        avatar.BuildCharacter();
    }

    public void ChangeBoots(bool plus)
    {
        if (avatar.activeRace.name == "HumanMaleDCS")
        {
            if (plus)
                currentFeetModelMale++;
            else
                currentFeetModelMale--;

            currentFeetModelMale = Mathf.Clamp(currentFeetModelMale, 0, FeetModelsMale.Count - 1);

            if (FeetModelsMale[currentFeetModelMale] == "None")
            {
                avatar.ClearSlot("Feet");
            }
            else
            {
                avatar.SetSlot("Feet", FeetModelsMale[currentFeetModelMale]);
            }
        }
        if (avatar.activeRace.name == "HumanFemaleDCS")
        {
            if (plus)
                currentFeetModelFemale++;
            else
                currentFeetModelFemale--;

            currentFeetModelFemale = Mathf.Clamp(currentFeetModelFemale, 0, FeetModelsFemale.Count - 1);

            if (FeetModelsFemale[currentFeetModelFemale] == "None")
            {
                avatar.ClearSlot("Feet");
            }
            else
            {
                avatar.SetSlot("Feet", FeetModelsFemale[currentFeetModelFemale]);
            }
        }


        avatar.BuildCharacter();
    }


}
