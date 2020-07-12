namespace Fuel.Infrastructure.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    static class DcsDriverFunctions
    {
        public const string PopulateDrivers = @"
                    -- FUNCTION: public.populatedrivers(integer)
                    
                    CREATE OR REPLACE FUNCTION public.populatedrivers(
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
                    		  INSERT INTO public.""DCS_DriverMaster"" (""DriverName"", ""DriverMobile"", ""CreatedDate"", ""ModifiedDate"")
                    
                              SELECT concat('Driver_', i), getRandomPhoneNumber(), now()::timestamp, null;
                            i:= i + 1;
                                END LOOP;
                                END;
                    $BODY$;
        ";
        public const string RemovePopulateDrivers = "DROP FUNCTION public.populatedrivers(integer);";
    }
}
