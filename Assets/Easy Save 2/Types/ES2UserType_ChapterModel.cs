
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_ChapterModel : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		ChapterModel data = (ChapterModel)obj;
		// Add your writer.Write calls here.
		writer.Write(data.ChapterID);
		writer.Write(data.EnemyType);
		writer.Write(data.EnemyLocPositin);
		writer.Write(data.EnemyLocRotationEuler);
		writer.Write(data.EnemyLocScale);

	}
	
	public override object Read(ES2Reader reader)
	{
		ChapterModel data = new ChapterModel();
		Read(reader, data);
		return data;
	}
	
	public override void Read(ES2Reader reader, object c)
	{
		ChapterModel data = (ChapterModel)c;
		// Add your reader.Read calls here to read the data into the object.
		data.ChapterID = reader.Read<System.Int32>();
		data.EnemyType = reader.ReadList<System.Int32>();
		data.EnemyLocPositin = reader.ReadList<UnityEngine.Vector3>();
		data.EnemyLocRotationEuler = reader.ReadList<UnityEngine.Vector3>();
		data.EnemyLocScale = reader.ReadList<UnityEngine.Vector3>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_ChapterModel():base(typeof(ChapterModel)){}
}
