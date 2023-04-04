import { ReactNode, useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import { TopicProps } from '../../interfaces/topic.interface';

import CardItem from '../../components/CardItem';

import './styles.scss'

export const TopicDetails = () => {
  const [topic, setTopic] = useState<TopicProps>();
  const {topicId} = useParams<string>()

  const getDataTopic = async () => {
    await fetch(process.env.REACT_APP_API + 'topics/' + Number(topicId))
      .then((resp: Response) => resp.json())
      .then((data: TopicProps) => {
        setTopic(data)
      })
  }

  useEffect(() => {
    if (topicId !== undefined) getDataTopic()
  }, [])

  const cardList: ReactNode = topic?.cards?.map(card => (
    <div key={card.id} className="topic-details__card-word">     
      <CardItem cardId={card.id} isShowCardButton={true}/>
    </div>
  ));

  return (
    <div className="topic-details">    
      <Link className="topic-details__button" to="/../">Back</Link>
      <div className="topic-details__content">
        {topic?.name}
      </div>
      <div className="topic-details__card-list">
        {
            cardList
        }
      </div>
    </div>
  )
}