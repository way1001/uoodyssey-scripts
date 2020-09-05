using System;
using Server;
using Server.Spells.Sixth;
using Server.Targeting;

namespace Server.Items
{
	public class ParalyzeFieldMagicStaff : BaseMagicStaff
	{
		[Constructable]
		public ParalyzeFieldMagicStaff() : base( MagicStaffEffect.Charges, 1, 7 )
		{
			IntRequirement = 35;
			SkillBonuses.SetValues( 1, SkillName.Magery, 60 );
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "6th Circle of Power" );
		}

		public ParalyzeFieldMagicStaff( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

		}

		public override void OnMagicStaffUse( Mobile from )
		{
			Cast( new ParalyzeFieldSpell( from, this ) );
		}
	}
}