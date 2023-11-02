Create table if not exists Posts (
CommentId serial primary key,
PostId Int, 
UserId Int,
TextBody varchar(500)
created_at timestamp DEFAULT current_timestamp,
updated_at timestamp DEFAULT current_timestamp
)