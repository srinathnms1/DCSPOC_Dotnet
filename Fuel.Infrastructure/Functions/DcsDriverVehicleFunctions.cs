namespace Fuel.Infrastructure.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    static class DcsDriverVehicleFunctions
    {
        public const string PopulateDriverVehicle = @"
                    -- FUNCTION: public.populatedrivervehicle(integer)
                    
                    CREATE OR REPLACE FUNCTION public.populatedrivervehicle(
                    	num integer)
                        RETURNS void
                        LANGUAGE 'plpgsql'
                    
                        COST 100
                        VOLATILE 
                    AS $BODY$
                    declare i int := 1;
                    BEGIN	   
                    	WHILE i <= num
                    		LOOP		  
                    		  INSERT INTO public.""DCS_DriverVehicle"" (""DriverVehicleId"", ""VehicleId"", ""DriverId"", ""CreatedDate"", ""ModifiedDate"")
                    
                              SELECT i, i, i, now()::timestamp, null;
                            i:= i + 1;
                                END LOOP;
                                END;
                    $BODY$;
        ";
        public const string RemovePopulateDriverVehicle = "DROP FUNCTION public.populatedrivervehicle(integer);";
    }
}
