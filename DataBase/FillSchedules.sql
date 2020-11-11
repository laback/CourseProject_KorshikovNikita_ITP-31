use Course1
go

alter proc FillSchedules
	as
		declare @mintrain int, @maxtrain int, @minstop int, @maxstop int, @count int, @randtrain int, @randstop int, @randday varchar(2), @days varchar(7) = 'обявояб', @pos int, @randdistance float, @randtimeofdep time, @rantimeofarrive time
		set @count = 20000
		select @mintrain = min(Trains.trainId),
			   @maxtrain = max(Trains.trainId),
			   @minstop = min(Stops.stopId),
			   @maxstop = max(Stops.stopId)
			   from Trains, Stops
		while @count > 0
			begin
				set @randtrain = Rand() * (@maxtrain + 1 - @mintrain) + @mintrain
				set @randstop = Rand() * (@maxstop + 1 - @minstop) + @minstop
				set @pos = Rand() * (8 - 1) + 1
				set @randday = SUBSTRING(@days, @pos, 1)
				set @randdistance = Round(Rand() * (200 - 100) + 200, 1)
				select @randtimeofdep = cast(convert(datetime, rand()*54777/100000) as time)
				select @rantimeofarrive = cast(convert(datetime, rand()*54777/100000) as time)
				insert into Schedules values(@randtrain, @randday, @randstop, @randdistance, @randtimeofdep, @rantimeofarrive)
				set @count = @count - 1
			end