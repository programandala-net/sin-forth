\ lib/pad.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require here.fs       \ `here`
require plus.fs       \ `+`
require slash-hold.fs \ `/hold`

get-order get-current

target-definitions

: pad ( -- ca )
  here /hold + ;

  \ doc{
  \
  \ pad ( -- ca )
  \
  \ _ca_ is the address of a transient region that can be used to
  \ hold data for intermediate processing. It's a fixed offset
  \ (`/hold` bytes) above `here`.
  \
  \ ``pad`` is  specifically intended as  a programmer
  \ convenience. No standard words use it.
  \
  \ See also: `/pad`.
  \
  \ }doc

set-current set-order
