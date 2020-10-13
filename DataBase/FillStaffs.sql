use Course1
go

create proc FillStaff as
	declare @mintrain int, @minpost int, @maxtrain int, @maxpost int, @count int, @randtrain int, @randpost int, @FIO varchar(100), @age int, @workExp int
	set @count = 20000
	select @minpost = min(Posts.postId),
		   @maxpost = max(Posts.postId),
		   @mintrain = min(Trains.trainId),
		   @maxtrain = max(Trains.trainId)
		   from Trains, Posts
	while @count > 0
		begin
			set @FIO =    char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65) + ' ' +char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65) + ' '
						 +char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
						 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
			set @age = rand()*(60 + 1 - 25) + 25
			set @workExp = rand()*(40 + 1 - 0) + 0
			set @randtrain = Rand()*(@maxtrain + 1 - @mintrain) + @mintrain
			set @randpost = Rand()*(@maxpost + 1 - @minpost) + @minpost
			insert into Staffs values(@FIO,@randtrain, @randpost,@age, @workExp)
			set @count = @count - 1
		end