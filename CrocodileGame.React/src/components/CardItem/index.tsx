import { FC, useEffect, useState } from 'react'
import { CardProps } from "../../interfaces/card.interface";

import CardModal from '../CardModal';

import './styles.scss'


interface CardItemProps {
    cardId: number
    isShowCardButton: boolean
}

const CardItem : FC<CardItemProps> = ({cardId, isShowCardButton}) =>  {
  const [card, setCard] = useState<CardProps>();
  const [isShowCardModal, setIsShowCardModal] = useState<boolean>(false)

  const getCard = async () => {
    await fetch(process.env.REACT_APP_API + 'cards/' + Number(cardId))
    .then((resp: Response) => resp.json())
    .then((data: CardProps) => {
      setCard(data)
    })
    .catch(e => console.log(e))
  } 

  useEffect(() => {
    if (cardId !== undefined) getCard()
  },[]) 

  const showCardModal = () => {
    setIsShowCardModal((prev: boolean) => !prev)
  }

  return (
    
    <div className= "card">
      <CardModal isShowCardModal={isShowCardModal} showCardModal={showCardModal} card={card}></CardModal>  
        <li className="card__list">
          {card?.word}
        </li>
        {isShowCardButton && <button onClick={() => showCardModal()} className="card__button">
          Edit Card
        </button>
        }
    </div>
  )
}

export default CardItem