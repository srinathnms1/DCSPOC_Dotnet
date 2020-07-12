namespace Fuel.Infrastructure.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    static class DcsFuelFunctions
    {
        public const string GetTankCapacity = @"
                        -- FUNCTION: public.gettankcapacity(integer, integer)
                        
                        CREATE OR REPLACE FUNCTION public.gettankcapacity(
                        	""upperLimit"" integer,
                        
                            ""lowerLimit"" integer)
                            RETURNS integer
                            LANGUAGE 'plpgsql'
                        
                            COST 100
                            VOLATILE
                        AS $BODY$declare
                            tankCapacity int;
                                    BEGIN
                                        tankCapacity = (((getrandom(""upperLimit"", ""lowerLimit"") + 99) / 100) * 100)::int;
                                    return tankCapacity;
                                    END;$BODY$;
        ";
        public const string RemoveGetTankCapacity = "DROP FUNCTION public.gettankcapacity(integer, integer);";
    }
}
