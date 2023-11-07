Create table if not exists Posts (
PostId serial primary key,
Slug varchar, 
Title varchar,
Description varchar,
TextBody varchar,
MetaTagTitle varchar,
MetaTagDescription varchar,
MetaTagKeywords varchar[],
created_at timestamp DEFAULT current_timestamp,
updated_at timestamp DEFAULT current_timestamp
)