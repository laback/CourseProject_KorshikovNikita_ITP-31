use Course1
go

create procedure FillTrains as

declare @count int, @type int, @isFirm int
set @count = 20000
while @count > 0
	begin
		set @type = Rand()*(4 - 1) + 1
		set @isFirm = Rand()*(2 - 0) + 0
		insert into Trains values(@type, @isFirm)
		set @count = @count - 1
	end