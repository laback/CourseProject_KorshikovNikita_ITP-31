use Course1
go

alter procedure FillTrains as

declare @count int, @type int, @isFirm int, @maxtype int, @mintype int
set @count = 20000
select @maxtype = max(typeId) from TypesOfTrains
select @mintype = min(typeId) from TypesOfTrains
while @count > 0
	begin
		set @type = Rand()*(@maxtype + 1 - @mintype) + @mintype
		set @isFirm = Rand()*(2 - 0) + 0
		insert into Trains values(@type, @isFirm)
		set @count = @count - 1
	end