namespace Fuel.Infrastructure.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    static class DcsDataPopulationFunctions
    {
        public const string PopulateData = @"
                -- FUNCTION: public.populateData(character varying, integer)
                
                CREATE OR REPLACE FUNCTION public.""populateData""(
                	""intervalPeriod"" character varying,
                	""dataInterval"" integer)
                    RETURNS void
                    LANGUAGE 'plpgsql'
                
                    COST 100
                    VOLATILE
                AS $BODY$declare i int := 1;
                j int := 0;
                workHours int;
                loadUnloadHours double precision = 0;
                        distanceTravelled double precision = 0;
                        startDate timestamp := DATE_TRUNC('second', CURRENT_TIMESTAMP::timestamp) - ""intervalPeriod""::interval;
                numOfDays int = (
                    EXTRACT(
                        epoch
                        FROM ""intervalPeriod""::interval
                	) / (24 * 60 * 60)
                );
                dayCount int = 0;
                driverCount int := count(1) from public.""DCS_DriverVehicle"";
                drivingHours double precision;
                        restingHours double precision;
                        vehicleRunningHour double precision;
                        vehicleStartTime timestamp;
                        vehicleEndTime timestamp;
                        restingStartTime timestamp;
                        restingEndTime timestamp;
                        vehicleAndResting double precision = 0;
                        driverServiceId int = 1;
                noOfDriving int;
                noOfResting int;
                drivingInsertTime double precision;
                        restingInsertTime double precision;
                        isDriving boolean;
                        noOfBreak int = 0;
                vehicleSpeed int := getRandom(120, 20);
                        currentVehicleSpeed int := getRandom(120, 20);
                        harshBreakCount int = 0;
                harshTurnCount int = 0;
                harshBreakApplied int = 0;
                harshTurnApplied int = 0;
                harshBreakInterval int;
                harshTurnInteral int;
                driverStartTime int;
                vehicleRealTimeInfoId int = 1;
                fuelInfoId int = 1;
                tankCapacity double precision;
                        currentVolume double precision = 0;
                        refuelVolume double precision = 0;
                        ignitionStatus int = 0;
                theftDay int = 0;
                leakageDay int = 0;
                canRefuel double precision = 0;
                        loadVolume int = 0;
                sourceLat double precision = 0;
                        sourceLong double precision = 0;
                        destLat double precision = 0;
                        destLong double precision = 0;
                        differenceofSource double precision = 0;
                        differenceofDestination double precision = 0;
                        latLong text[];
                        latLongSplit int = 0;
                locationId int = 1;
                
                /*Code */
                BEGIN
                    WHILE i <= driverCount LOOP
                            SELECT ""TankCapacity"" INTO tankCapacity from public.""DCS_VehicleMaster"" 
                			where ""VehicleId"" = (SELECT ""VehicleId"" from public.""DCS_DriverVehicle"" where ""DriverVehicleId"" = i);
                            currentVolume = tankCapacity;
                            startDate = DATE_TRUNC('day', now()::timestamp) + ('1 day'::interval) - ""intervalPeriod""::interval;
                            /*Implemented only for month*/
                            IF numOfDays >= 30 
                                THEN theftDay = getRandom(1, 15);
                        leakageDay = getRandom(16, 29);
                        END IF;
                
                        /*Driver Service*/
                        WHILE dayCount<numOfDays LOOP
                            driverStartTime = getRandom(9, 7);
                        startDate = startDate + concat(driverStartTime, ' hour')::interval + concat(dayCount, ' day')::interval;
                                workHours = getRandom(10, 7);
                        drivingHours = getRandom(8, 6);
                        restingHours = getrandomwithnumeric(2, 1);
                        noOfDriving = getRandom(3, 2);
                        drivingInsertTime = round(drivingHours::numeric / noOfDriving, 2);
                        restingInsertTime = round(restingHours::numeric / noOfDriving, 2);
                
                        select regexp_split_to_array(""getMapRandomSoureAndDestination""(), ',') into latLong;
                        select regexp_replace(latLong[1], '[{},]+', '', 'g')::double precision into sourceLat;
                        select regexp_replace(latLong[2], '[{},]+', '', 'g')::double precision into sourceLong;
                        select regexp_replace(latLong[3], '[{},]+', '', 'g')::double precision into destLat;
                        select regexp_replace(latLong[4], '[{},]+', '', 'g')::double precision into destLong;
                
                
                        WHILE noOfBreak<noOfDriving LOOP
                                IF (noOfBreak != noOfDriving - 1) THEN
                                    vehicleStartTime = startDate;
                        vehicleEndTime = startDate + concat(drivingInsertTime, ' Hour')::interval;
                
                                            /*vehicle info*/
                                            /*yet to do for Day basis*/
                                            vehicleRunningHour = DATE_PART('epoch', vehicleEndTime - vehicleStartTime) / 3600;
                                            ignitionStatus = 1;
                							
                							latLongSplit = (((vehicleRunningHour* 60)/""dataInterval"") - 2);
                
                							IF sourceLat > destLat THEN
                
                                                differenceofSource = TRUNC(((sourceLat - destLat) / latLongSplit)::numeric,6);
                                            END IF;
                        IF sourceLat<destLat THEN
                            differenceofSource = TRUNC(((destLat - sourceLat) / latLongSplit)::numeric, 6);
                        END IF;
                        IF sourceLong > destLong THEN
                
                                                differenceofDestination = TRUNC(((sourceLong - destLong) / latLongSplit)::numeric,6);
                                            END IF;
                        IF sourceLong<destLong THEN
                            differenceofDestination = TRUNC(((destLong - sourceLong) / latLongSplit)::numeric, 6);
                        END IF;
                
                        WHILE j <= (vehicleRunningHour* 60) LOOP
                               currentVehicleSpeed = getRandom(120, 20);
                        IF(vehicleSpeed - currentVehicleSpeed) > 50 THEN harshBreakApplied = 1::bit;
                        END IF;
                        IF(vehicleSpeed - currentVehicleSpeed) > 30 THEN harshTurnApplied = 1::bit;
                        END IF;
                
                        CASE
                        WHEN currentVehicleSpeed >= 60 AND currentVehicleSpeed <= 80 THEN currentVolume = currentVolume - getrandomwithnumeric(0.5, 1);
                        WHEN currentVehicleSpeed > 80 AND currentVehicleSpeed <= 100 THEN currentVolume = currentVolume - getrandomwithnumeric(1, 1.5);
                        WHEN currentVehicleSpeed > 100 AND currentVehicleSpeed <= 120 THEN currentVolume = currentVolume - getrandomwithnumeric(1.5, 2);
                        ELSE currentVolume = currentVolume - getrandomwithnumeric(0.1, 0.9);
                        END case;
                                                    
                                                    /*Leakage*/
                                                    IF dayCount = leakageDay AND(j = 110 OR j = 120)
                                                        THEN currentVolume = currentVolume - getrandomwithnumeric(5, 7);
                        raise notice 'leakageDay %', startDate;
                        END IF;
                
                
                        /*Location Updation*/
                        IF j > 0 THEN
                            IF sourceLat = destLat AND sourceLong = destLong THEN
                
                                                            raise notice 'Success j %', j;
                        END IF;
                        IF sourceLat > destLat THEN
                
                                                            sourceLat = sourceLat - differenceofSource;		
                                                        END IF;
                        IF sourceLat<destLat THEN
                            sourceLat = sourceLat + differenceofSource;
                        END IF;
                        IF sourceLong > destLong THEN
                
                                                        sourceLong = sourceLong - differenceofDestination;
                										END IF;
                        IF sourceLong<destLong THEN
                            sourceLong = sourceLong + differenceofDestination;
                        END IF;
                        END IF;
                									--sourceLat = TRUNC(sourceLat::numeric, 6);
                									--sourceLong = TRUNC(sourceLong::numeric, 6);
                        INSERT INTO public.""DCS_VehicleRealTimeInfo"" (
                                                            ""VehicleRealTimeInfoId"",
                                                            ""DriverVehicleId"",
                                                            ""PacketTime"",
                                                            ""VehicleSpeed"",
                                                            ""HarshTurning"",
                                                            ""HarshBreaking"",
                                                            ""IgnitionStatus"",
                                                            ""LoadVolume"",
                                                            ""CreatedDate"",
                                                            ""ModifiedDate""
                                                        )
                                                    SELECT vehicleRealTimeInfoId,
                                                        i,
                                                        startDate,
                                                        currentVehicleSpeed,
                                                        harshBreakApplied,
                                                        harshTurnApplied,
                                                        ignitionStatus:: bit,
                                                        0,
                                                        now()::timestamp,
                                                        null;
                										
                									INSERT INTO public.""DCS_Location"" (
                                                            ""LocationId"",
                                                            ""VehicleRealTimeInfoId"",
                                                            ""Latitude"",
                                                            ""Longitude""
                                                        )
                                                    SELECT locationId,
                                                        VehicleRealTimeInfoId,
                                                        TRUNC(sourceLat::numeric, 6),
                                                        TRUNC(sourceLong::numeric, 6);
                
                        INSERT INTO public.""DCS_FuelInfo"" (
                                                            ""DriverVehicleId"",
                                                            ""FuelInfoId"",
                                                            ""CurrentVolume"",
                                                            ""RefuelVolume"",
                                                            ""PacketTime""
                                                        )
                                                    SELECT i,
                                                        fuelInfoId,
                                                        currentVolume,
                                                        0,
                                                        startDate;
                        j := j + ""dataInterval"";
                                                    vehicleSpeed = currentVehicleSpeed;
                                                    distanceTravelled = round(((distanceTravelled + (currentVehicleSpeed* ""dataInterval"")) / 60)::numeric, 2);
                                                    startDate := startDate + concat(""dataInterval"", ' minutes')::interval;
                                                    harshBreakCount := harshBreakCount + ""dataInterval"";
                                                    harshTurnCount := harshTurnCount + ""dataInterval"";
                                                    vehicleRealTimeInfoId = vehicleRealTimeInfoId + 1;
                                                    fuelInfoId = fuelInfoId + 1;
                									locationId = locationId + 1;
                                                    harshBreakApplied = 0;
                                                    harshTurnApplied = 0;
                                            END LOOP;
                        j := 0;
                							
                                            /*resting entry*/
                                            restingStartTime = vehicleEndTime + interval '1 second';
                                            restingEndTime = restingStartTime + concat(restingInsertTime, ' Hour')::interval;
                                            restingHours = DATE_PART('epoch', restingEndTime - restingStartTime) / 3600;
                                            WHILE j <= ((DATE_PART('epoch', restingEndTime - restingStartTime) / 3600) * 60) LOOP
                                                    ignitionStatus = 0;
                
                        /*Theft*/
                        IF dayCount = theftDay AND(j = 10) AND currentVolume > 50 THEN
                       raise notice 'theftDay % currentVolume %', startDate, currentVolume;
                										IF currentVolume > 50 AND currentVolume <= 70
                
                                                            THEN currentVolume = currentVolume - getrandomwithnumeric(40, 50); raise notice 'Theft Occured %', startDate;
                        END IF;
                        IF currentVolume > 70 AND currentVolume <= 100
                
                                                            THEN currentVolume = currentVolume - getrandomwithnumeric(50, 70); raise notice 'Theft Occured %', startDate;
                        END IF;
                        IF currentVolume > 100
                
                                                            THEN currentVolume = currentVolume - getrandomwithnumeric(75, 80); raise notice 'Theft Occured %', startDate;
                        END IF;
                        END IF;
                
                        INSERT INTO public.""DCS_VehicleRealTimeInfo"" (
                                                            ""VehicleRealTimeInfoId"",
                                                            ""DriverVehicleId"",
                                                            ""PacketTime"",
                                                            ""VehicleSpeed"",
                                                            ""HarshTurning"",
                                                            ""HarshBreaking"",
                                                            ""IgnitionStatus"",
                                                            ""LoadVolume"",
                                                            ""CreatedDate"",
                                                            ""ModifiedDate""
                                                        )
                                                    SELECT vehicleRealTimeInfoId,
                                                        i,
                                                        startDate,
                                                        0,
                                                        0,
                                                        0,
                                                        ignitionStatus::bit,
                                                        0,
                                                        now()::timestamp,
                                                        null;
                										
                									INSERT INTO public.""DCS_Location"" (
                                                            ""LocationId"",
                                                            ""VehicleRealTimeInfoId"",
                                                            ""Latitude"",
                                                            ""Longitude""
                                                        )
                                                    SELECT locationId,
                                                        VehicleRealTimeInfoId,
                                                        sourceLat,
                                                        sourceLong;
                
                        INSERT INTO public.""DCS_FuelInfo"" (
                                                            ""DriverVehicleId"",
                                                            ""FuelInfoId"",
                                                            ""CurrentVolume"",
                                                            ""RefuelVolume"",
                                                            ""PacketTime""
                                                        )
                                                    SELECT i,
                                                        fuelInfoId,
                                                        currentVolume,
                                                        0,
                                                        startDate;
                        j := j + ""dataInterval"";
                                                    startDate := startDate + concat(""dataInterval"", ' minutes')::interval;
                                                    fuelInfoId = fuelInfoId + 1;
                									locationId = locationId + 1;
                                                    vehicleRealTimeInfoId = vehicleRealTimeInfoId + 1;
                                            END LOOP;
                        j := 0;
                							
                                        END IF;
                
                        IF(noOfBreak = noOfDriving - 1)
                                            THEN loadUnloadHours = workHours - vehicleAndResting;
                        restingStartTime = null;restingEndTime = null;
                                                restingHours = 0;
                                                vehicleStartTime = null;vehicleEndTime = null;
                                                vehicleRunningHour = 0;
                                                /*Load Unload, refuel*/
                                                WHILE j <= (loadUnloadHours* 60) LOOP
                                                       IF currentVolume <= 100 THEN refuelVolume = tankCapacity - currentVolume; currentVolume = currentVolume + refuelVolume;
                                                        END IF;
                        loadVolume = (loadUnloadHours* 60) - j;
                                                        ignitionStatus = 0;	
                                                        INSERT INTO public.""DCS_VehicleRealTimeInfo"" (
                                                                ""VehicleRealTimeInfoId"",
                                                                ""DriverVehicleId"",
                                                                ""PacketTime"",
                                                                ""VehicleSpeed"",
                                                                ""HarshTurning"",
                                                                ""HarshBreaking"",
                                                                ""IgnitionStatus"",
                                                                ""LoadVolume"",
                                                                ""CreatedDate"",
                                                                ""ModifiedDate""
                                                            )
                                                        SELECT vehicleRealTimeInfoId,
                                                            i,
                                                            startDate,
                                                            0,
                                                            0,
                                                            0,
                                                            ignitionStatus:: bit,
                                                            loadVolume,
                                                            now()::timestamp,
                                                            null;
                										
                										INSERT INTO public.""DCS_Location"" (
                                                            ""LocationId"",
                                                            ""VehicleRealTimeInfoId"",
                                                            ""Latitude"",
                                                            ""Longitude""
                                                        )
                										SELECT locationId,
                                                            VehicleRealTimeInfoId,
                                                            sourceLat,
                                                            sourceLong;
                
                        INSERT INTO public.""DCS_FuelInfo"" (
                                                                ""DriverVehicleId"",
                                                                ""FuelInfoId"",
                                                                ""CurrentVolume"",
                                                                ""RefuelVolume"",
                                                                ""PacketTime""
                                                            )
                                                        SELECT i,
                                                            fuelInfoId,
                                                            currentVolume,
                                                            refuelVolume,
                                                            startDate;
                        j := j + ""dataInterval"";
                                                        distanceTravelled = 0;
                                                        startDate := startDate + concat(""dataInterval"", ' minutes')::interval;
                                                        vehicleRealTimeInfoId = vehicleRealTimeInfoId + 1;
                                                        fuelInfoId = fuelInfoId + 1;
                										locationId = locationId + 1;
                                                        refuelVolume = 0;
                                                END LOOP;
                        j := 0;
                                        END IF;
                
                                        -- IF restingStartTime != NULL AND restingEndTime != NULL THEN restingHours = DATE_PART('epoch', restingEndTime - restingStartTime) / 3600;
                                        -- END IF;
                
                        INSERT INTO public.""DCS_DriverService"" (
                                                ""DriverServiceId"",
                                                ""DriverVehicleId"",
                                                ""VehicleStartTime"",
                                                ""VehicleEndTime"",
                                                ""RestingStartTime"",
                                                ""RestingEndTime"",
                                                ""RestTimeHours"",
                                                ""DrivingTimeHours"",
                                                ""WorkTimeHours"",
                                                ""DistanceTravelled"",
                                                ""CreatedDate"",
                                                ""ModifiedDate""
                                            )
                                        SELECT driverServiceId,
                                            i,
                                            vehicleStartTime,
                                            vehicleEndTime,
                                            restingStartTime,
                                            restingEndTime,
                                            restingHours,
                                            vehicleRunningHour,
                                            loadUnloadHours,
                                            distanceTravelled,
                                            startDate,
                                            null;
                
                        vehicleAndResting = vehicleAndResting + vehicleRunningHour + restingHours;
                                        startDate = startDate + interval '1 second';
                                        driverServiceId = driverServiceId + 1;
                                        noOfBreak = noOfBreak + 1;
                                END LOOP;
                        ignitionStatus = 0;
                                distanceTravelled = 0;
                                loadUnloadHours = 0;
                                vehicleAndResting = 0;
                                noOfBreak := 0;
                				dayCount = dayCount + 1;
                				startDate = DATE_TRUNC('day', now()::timestamp) + ('1 day'::interval) - ""intervalPeriod""::interval;
                            END LOOP;
                        i := i + 1;
                            dayCount = 0;
                    END LOOP;
                        END;$BODY$;
        ";
        public const string RemovePopulateData = @"DROP FUNCTION public.""populateData""(character varying, integer);";
    }
}
