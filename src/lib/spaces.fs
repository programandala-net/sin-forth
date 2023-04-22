\ lib/spaces.fs

\ This file is part of Sin Forth.

\ This file adds `spaces` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require b-l.fs   \ `bl`
require emits.fs \ `emits`
require swap.fs  \ `swap`

get-order get-current

target-definitions

: spaces ( n -- )
  bl swap emits ;

  \ doc{
  \
  \ spaces ( n -- )
  \
  \ If _n_ is greater than zero, display _n_ spaces.
  \
  \ See also: `space`, `bl`, `emits`.
  \
  \ }doc

set-current set-order
