#ifndef GENERICS_H
#define GENERICS_H

namespace Generics
{
	template<typename V>
	struct StackNode
	{
		V value;
		StackNode* below;

		StackNode(const V& val, StackNode* node) : value(val)
		{
			below = node;
		}
	};

	template<typename V>
	class SimpleStack
	{
	public:
		SimpleStack()
		{
			top = 0;
		}

		void Push(const V& element) 
		{
			top = new StackNode<V>(element, top);
		}

		V Pop()
		{
			V element = top->value;
			StackNode<V>* node = top;
			top = top->below;
			delete node;
			return element;
		}

		bool Empty() const
		{
			return top == 0;
		}

		~SimpleStack()
		{
			while(top) Pop();
		}

		SimpleStack(const SimpleStack&);
		SimpleStack& operator=(const SimpleStack&);

		//nested class 
		class Iterator
		{
		public:
			Iterator(StackNode<V>* node)
			{
				current = node;
			}

			V& operator*() const
			{
				return current->value;
			}

			V* operator->() const
			{
				return &current->value;
			}

			bool operator!=(const Iterator& other) const
			{
				return current != other.current;
			}

			Iterator& operator++()
			{
				current = current->below;
				return *this;
			}
		private:
			StackNode<V>* current;
		};

		Iterator begin() const
		{
			return Iterator(top);
		}

		Iterator end() const
		{
			return Iterator(0);
		}

	private:
		StackNode<V>* top;
	};
}
template<typename I, typename P>
int Count(I begin, I end, P check)
{
	int count = 0;

	for(I i = begin; i != end; ++i)
	{
		if(check(*i))
			++count;
	}

	return count;
}

#endif


