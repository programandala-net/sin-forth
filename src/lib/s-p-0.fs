\ lib/s-p-0.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

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
