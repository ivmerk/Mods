Create table if not exists Posts (
PostId serial primary key,
Slug varchar(50), 
Title varchar(50),
Description varchar(100),
TextBody varchar(500)
created_at timestamp DEFAULT current_timestamp,
updated_at timestamp DEFAULT current_timestamp
)