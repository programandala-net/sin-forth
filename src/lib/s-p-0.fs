\ lib/s-p-0.fs

\ This file is part of Sin Forth.

\ This file adds `sp0` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
