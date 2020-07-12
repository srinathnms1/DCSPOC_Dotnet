namespace Fuel.Infrastructure.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    static class DcsVehicleFunctions
    {
        public const string PopulateVehicles = @"
                    -- FUNCTION: public.populatevehicles(integer)
                    
                    CREATE OR REPLACE FUNCTION public.populatevehicles(
                    	num integer)
                        RETURNS void
                        LANGUAGE 'plpgsql'
                    
                        COST 100
                        VOLATILE 
                    AS $BODY$declare i int := 1;
                    BEGIN	   
                    	WHILE i <= num
                    		LOOP		  
                    		  INSERT INTO public.""DCS_VehicleMaster"" (""VehicleId"",""VehicleLicenseNo"", ""VehicleName"", ""CreatedDate"", ""ModifiedDate"", ""TankCapacity"")
                    
                              SELECT i, concat('Vehicle_', i), getRandomLicenseNo(), now()::timestamp, null, getTankCapacity(200, 500);
                            i:= i + 1;
                                END LOOP;
                                END;
                    $BODY$;
        ";
        public const string RemovePopulateVehicles = "DROP FUNCTION public.populatevehicles(integer);";
    }
}
