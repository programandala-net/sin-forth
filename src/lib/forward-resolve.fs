\ lib/forward-resolve.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1303+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

get-order get-current

compiler-definitions

: >resolve ( orig -- )
  t-here swap t-! ;

  \ doc{
  \
  \ >resolve  Compilation: ( orig -- ) "forward-resolve"
  \
  \ Resolve a forward branch by placing the address of the current
  \ data-space pointer into the address _orig_ left by `>mark`.
  \
  \ See also: `t-here`, `<resolve`, `>mark,`.
  \
  \ }doc

set-current set-order
