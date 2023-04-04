import { CardProps } from "./card.interface"

export interface TopicProps {
    id: number
    name: string
    cards?: CardProps[]
}