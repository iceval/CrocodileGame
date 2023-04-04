import { FC, ReactNode, useState } from 'react'
import { Link } from 'react-router-dom';
import { TopicProps } from "../../interfaces/topic.interface";

import CardItem from '../CardItem';

import './styles.scss'

interface TopicItemProps {
    topic: TopicProps
}

const TopicItem : FC<TopicItemProps> = ({topic}) =>  {
  const [isShowList, setIsShowList] = useState<boolean>(false)

  const showList = () => {
    setIsShowList((prev: boolean) => !prev)
  }
  
  const handleShow = () => {
    showList()
  }

  const cardList: ReactNode = topic.cards?.map(card => (
    <div key={card.id} className="topic-item__card-button">
      <CardItem cardId={card.id}  isShowCardButton={false}/>
    </div>
  ));

  return (
    <div className="topic-item">
      <button className="topic-item__content" onClick={() => {handleShow()}}>
        {topic.name}<span className={`topic-item__arrow ${isShowList ? "active" : ""}`} ></span>
      </button>
      <div className="topic-item__card-list">
        {
          isShowList && (
            <>
            {cardList}
            <Link className="topic-item__details" to={`/editor/topic/${topic.id}`}>more</Link>
            </>
          )
        }
      </div>
    </div>
  )
}

export default TopicItem