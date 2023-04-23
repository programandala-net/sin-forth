\ lib/spaces.fs
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
