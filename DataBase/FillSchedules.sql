use Course1
go

alter proc FillSchedules
	as
		declare @mintrain int, @maxtrain int, @minstop int, @maxstop int, @count int, @randtrain int, @randbegin int, @randday varchar(2), @days varchar(7) = 'обявояа', @pos int, @randend int, @randdistance float, @randtime time
		set @count = 20000
		select @mintrain = min(Trains.trainId),
			   @maxtrain = max(Trains.trainId),
			   @minstop = min(Stops.stopId),
			   @maxstop = max(Stops.stopId)
			   from Trains, Stops
		while @count > 0
			begin
				set @randtrain = Rand() * (@maxtrain + 1 - @mintrain) + @mintrain
				set @randbegin = Rand() * (@maxstop + 1 - @minstop) + @minstop
				set @randend = Rand() * (@maxstop + 1 - @minstop) + @minstop
				set @pos = Rand()* 7
				set @randday = SUBSTRING(@days, @pos, 2)
				set @randdistance = Round(Rand() * (200 - 100) + 200, 1)
				select @randtime = cast(convert(datetime, rand()*54777/100000) as time)
				insert into Schedules values(@randtrain, @randday, @randbegin, @randend, @randdistance, @randtime)
				set @count = @count - 1
			end