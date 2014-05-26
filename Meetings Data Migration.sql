--select * from meetings
insert into meetings (PresentationTitle, SpeakerName, SpeakerBio, SpeakerTwitter, Description, Date, StartTime, SurveyURL) 
select 
	PresentationTitle,
	SpeakerName, 
	case when SpeakerBio is null then '' else SpeakerBio end as SpeakerBio,
	case when SpeakerTwitter IS NOT NULL AND LEN(RTRIM(LTRIM(SpeakerTwitter))) > 0
			then case when SUBSTRING(SpeakerTwitter, 1, 1) = '@' then SpeakerTwitter
			     else '@' + SpeakerTwitter
				 end
	end as SpeakerTwitter,
	case when Description is null then '' else Description end as Description,
	Date,
	cast(StartTime as datetime) as StartTime,
	SurveyURL
from SQL2008_618331_lrdnugweb.dbo.Meetings 
--where SpeakerBio is null
order by date