\ lib/s-p-0.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1824+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

get-order get-current

target-definitions

data-stack-bottom constant sp0

  \ doc{
  \
  \ sp0 ( -- a )
  \
  \ Return address _a_, which is the bottom (high memory) address of
  \ the data stack.
  \
  \ See also: `init-data-stack`.
  \
  \ }doc

set-current set-order
