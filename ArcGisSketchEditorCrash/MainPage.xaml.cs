﻿using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Reactive.Bindings;
using Map = Esri.ArcGISRuntime.Mapping.Map;

namespace ArcGisSketchEditorCrash;

public partial class MainPage
{
    public ReactiveProperty<Map> MyMap { get; } = new();
    public ReactiveProperty<SketchEditor> MySketchEditor { get; } = new(new SketchEditor());


    public MainPage()
	{
		InitializeComponent();

        InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        var geom = Geometry.FromJson(
            "{\"rings\":[[[28.309655000000078,70.540905000000066],[28.403449000000023,70.510430000000042],[28.399771000000044,70.500051000000042],[28.35941500000007,70.487775000000056],[28.33516000000003,70.476974000000041],[28.309078000000056,70.450761000000057],[28.304184000000078,70.446040000000039],[28.295386000000065,70.439965000000029],[28.28324200000003,70.433109000000059],[28.268496000000027,70.425224000000071],[28.25207400000005,70.418677000000059],[28.227295000000026,70.410380000000032],[28.223170000000039,70.408862000000056],[28.218629000000078,70.406914000000029],[28.215925000000027,70.405530000000056],[28.213705000000061,70.404005000000041],[28.200345000000027,70.405896000000041],[28.199266000000023,70.405929000000071],[28.199054000000046,70.405939000000046],[28.198916000000054,70.405992000000083],[28.194075000000055,70.40670300000005],[28.192904000000055,70.406964000000073],[28.181576000000064,70.409444000000065],[28.179857000000027,70.408524000000057],[28.178476000000046,70.409169000000077],[28.175197000000026,70.409530000000075],[28.171282000000076,70.409568000000036],[28.165715000000034,70.409115000000043],[28.165634000000068,70.409203000000048],[28.165445000000034,70.409338000000048],[28.165144000000055,70.409470000000056],[28.164892000000066,70.409635000000037],[28.164721000000043,70.409825000000069],[28.164509000000066,70.410019000000034],[28.164243000000056,70.410283000000049],[28.164035000000069,70.410371000000055],[28.163829000000078,70.410431000000074],[28.163745000000063,70.410492000000033],[28.163700000000063,70.410584000000028],[28.163732000000039,70.410669000000041],[28.163766000000066,70.410845000000052],[28.163861000000054,70.410942000000034],[28.163830000000075,70.411027000000047],[28.163722000000064,70.411110000000065],[28.163490000000024,70.411156000000062],[28.163278000000048,70.41121400000003],[28.163042000000075,70.411332000000073],[28.162894000000051,70.411421000000075],[28.162751000000071,70.411577000000079],[28.162631000000033,70.411681000000044],[28.162418000000059,70.411737000000073],[28.162083000000052,70.411801000000082],[28.161881000000051,70.411914000000081],[28.16161100000005,70.412030000000073],[28.157516000000044,70.414259000000072],[28.129609000000073,70.415067000000079],[28.115793000000053,70.42289500000004],[28.143167000000062,70.441414000000066],[28.155598000000055,70.447324000000037],[28.171614000000034,70.45575000000008],[28.185207000000048,70.460771000000079],[28.196145000000058,70.465699000000029],[28.235099000000048,70.468457000000058],[28.274880000000053,70.478925000000061],[28.284531000000072,70.493888000000084],[28.320109000000059,70.498712000000069],[28.318239000000062,70.506216000000052],[28.309655000000078,70.540905000000066]]],\"spatialReference\":{\"wkid\":4258}}");

        // Setup the map
        var map = new Map(BasemapStyle.ArcGISTopographic)
        {
            InitialViewpoint = new Viewpoint(geom, 20_000),
        };

        await map.LoadAsync();
        MyMap.Value = map;

        var editedGeom = await MySketchEditor.Value.StartAsync(geom);
        System.Diagnostics.Debug.WriteLine(editedGeom?.ToJson());
    }
}
